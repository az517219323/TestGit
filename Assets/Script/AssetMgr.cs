using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


public interface IAsset
{
    Type Type { get; }
    bool IsValid { get; }
    int RefCount { get; set; }
    void Release();
}

public interface IAsset<T> : IAsset
{
    AsyncOperationHandle<T> OpHandle { get; }
    T Result { get; }
    UniTask<T> LoadAssetAsync(string address, CancellationToken cancellationToken);
}

public interface IAssetMgr
{
    Type Type { get; }
    void ReleaseAsset(string address);
}

public interface IAssetMgr<T> : IAssetMgr
{
    UniTask<T> LoadAssetAsync(string address, CancellationToken cancellationToken);
}


public abstract class Asset<T> : IAsset<T>
{
    public Type Type => typeof(T);
    public AsyncOperationHandle<T> OpHandle { get; private set; }
    public T Result { get; private set; }
    public bool IsValid => Result != null;
    public int RefCount { get; set; }

    public async UniTask<T> LoadAssetAsync(string address, CancellationToken cancellationToken)
    {
        if (IsValid) return Result;
        var handle = Addressables.LoadAssetAsync<T>(address);
        OpHandle = handle;
        await handle.WithCancellation(cancellationToken);
        Result = handle.Result;
        return Result;
    }

    public void Release()
    {
        Addressables.Release(OpHandle);
        Result = default;
    }
}

public abstract class AssetMgr<T> : IAssetMgr<T>
{
    public Type Type => typeof(T);

    private readonly Dictionary<string, IAsset<T>> _loadedAssets = new Dictionary<string, IAsset<T>>();

    public async UniTask<T> LoadAssetAsync(string address, CancellationToken cancellationToken)
    {
        if (_loadedAssets.TryGetValue(address, out var asset))
        {
            asset.RefCount++;
            return (T)asset.Result;
        }

        var newAsset = GetNewAsset();
        await newAsset.LoadAssetAsync(address, cancellationToken);
        newAsset.RefCount = 1;
        _loadedAssets[address] = newAsset;
        return newAsset.Result;
    }

    public void ReleaseAsset(string address)
    {
        if (_loadedAssets.TryGetValue(address, out var asset))
        {
            asset.RefCount--;
            if (asset.RefCount <= 0)
            {
                asset.Release();
                _loadedAssets.Remove(address);
            }
        }
    }

    protected abstract IAsset<T> GetNewAsset();
}


public class SceneAsset:IAsset
{
    public Type Type => typeof(SceneInstance);
    public bool IsValid { get; private set; }
    public int RefCount { get; set; }
    private bool IsLoading { get; set; }
    private AsyncOperationHandle<SceneInstance> OpHandle{ get; set; }
    public float Progress
    {
        get
        {
            if (IsValid) return 1f;
            return IsLoading ? OpHandle.PercentComplete : 0f;
        }
    }

    public async UniTask LoadSceneAsync(string address,CancellationToken cancellationToken,Action completed)
    {
        await LoadSceneAsync(address, LoadSceneMode.Single, true, 100, cancellationToken,completed);
    }

    public async UniTask LoadSceneAsync(string address, LoadSceneMode loadMode, bool activateOnLoad, int priority, CancellationToken cancellationToken, Action completed = null)
    {
        OpHandle =  Addressables.LoadSceneAsync(address, loadMode, activateOnLoad, priority);
        IsLoading = true;
        await OpHandle.WithCancellation(cancellationToken);
        IsValid = true;
        completed?.Invoke();
    }
    
    public void Release()
    {
        Addressables.UnloadSceneAsync(OpHandle,true);
        IsValid = false;
    }
}

public class SceneAssetMgr : IAssetMgr
{
    public Type Type  => typeof(SceneInstance);
    
    private readonly Dictionary<string, SceneAsset> _loadedAssets = new Dictionary<string, SceneAsset>();

    public async UniTask<SceneAsset> LoadSceneAsync(string address, LoadSceneMode loadMode, bool activateOnLoad, int priority, CancellationToken cancellationToken)
    {
        if (_loadedAssets.TryGetValue(address, out var asset))
        {
            //asset.RefCount++;
            return asset;
        }

        var newAsset = GetNewAsset();
        await newAsset.LoadSceneAsync(address, loadMode, activateOnLoad, priority, cancellationToken);
        //newAsset.RefCount = 1;
        _loadedAssets[address] = newAsset;
        return newAsset;
    }
    
    public void ReleaseAsset(string address)
    {
        if (_loadedAssets.TryGetValue(address, out var sceneAsset))
        {
            sceneAsset.Release();
            _loadedAssets.Remove(address);
        }
    }

    public float Progress(string address)
    {
        if (_loadedAssets.TryGetValue(address, out var sceneAsset))
        {
            return sceneAsset.Progress;
        }
        return -1;
    }
    
    
    private SceneAsset GetNewAsset()
    {
        return new SceneAsset();
    }
}



public class DefaultAsset<T> : Asset<T>
{
}

public class DefaultAssetMgr<T> : AssetMgr<T>
{
    protected override IAsset<T> GetNewAsset()
    {
        return new DefaultAsset<T>();
    }
}


public class ObjectAsset<T> : Asset<T> where T : UnityEngine.Object
{
}


public class ObjectAssetMgr<T> : AssetMgr<T> where T : UnityEngine.Object
{
    protected override IAsset<T> GetNewAsset()
    {
        return new ObjectAsset<T>();
    }
}


public interface IAssetMgrFactory
{
    IAssetMgr<T> GetAssetManager<T>();
    IAssetMgr<T> GetAssetManager<T>(string address);
}

public class AssetMgrFactory : IAssetMgrFactory
{
    private readonly Dictionary<Type, IAssetMgr> _cacheTypeMap = new Dictionary<Type, IAssetMgr>();
    private readonly Dictionary<string, IAssetMgr> _cacheAddressMap = new Dictionary<string, IAssetMgr>();

    public IAssetMgr<T> GetAssetManager<T>()
    {
        var type = typeof(T);
        if (_cacheTypeMap.TryGetValue(type, out var manager))
        {
            return manager as AssetMgr<T>;
        }

        AssetMgr<T> newManager;
        if (typeof(UnityEngine.Object).IsAssignableFrom(type))
        {
            newManager = new ObjectAssetMgr<UnityEngine.Object>() as AssetMgr<T>;
            //newManager = (AssetMgr<T>)Activator.CreateInstance(typeof(ObjectAssetMgr<>).MakeGenericType(type));
        }
        else if (type.IsValueType)
        {
            newManager = new DefaultAssetMgr<T>();
        }
        else
        {
            throw new NotSupportedException($"Type {type.Name} is not supported.");
        }

        _cacheTypeMap[type] = newManager;
        return newManager;
    }

    public IAssetMgr<T> GetAssetManager<T>(string address)
    {
        if (_cacheAddressMap.TryGetValue(address, out var manager))
        {
            return manager as IAssetMgr<T>;
        }
        var mgr = GetAssetManager<T>();
        _cacheAddressMap[address] = mgr;
        return mgr;
    }
}


public class ResLoadMgr
{
    private IAssetMgrFactory _assetMgrFactory;
    private readonly Dictionary<string, IAssetMgr> _addressToAssetMgrMap = new Dictionary<string, IAssetMgr>();

    public void Init()
    {
        _assetMgrFactory = new AssetMgrFactory();
    }
    
    public async UniTask<T> LoadAssetAsync<T>(string address, CancellationToken cancellationToken)
    {
        var assetMgr = _assetMgrFactory.GetAssetManager<T>(address);
        try
        {
            var result = await assetMgr.LoadAssetAsync(address, cancellationToken);
            _addressToAssetMgrMap[address] = assetMgr;
            return result;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to load asset at {address}", ex);
        }
    }

    public void ReleaseAsset(string address)
    {
        if (_addressToAssetMgrMap.TryGetValue(address, out var mgr))
        {
            mgr.ReleaseAsset(address);
        }
    }
}