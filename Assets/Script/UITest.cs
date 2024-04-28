using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UITest : EditorWindow
{
    public RenderTexture go;
    // Start is called before the first frame update

    [MenuItem("Tools/ExportImage")]
    static void Init()
    {
        UITest window = (UITest)EditorWindow.GetWindow(typeof(UITest), false, "ExportImage", true);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        go = (RenderTexture)EditorGUILayout.ObjectField(go, typeof(RenderTexture), true, GUILayout.Width(200), GUILayout.Height(30));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("导出图片", GUILayout.Height(30)))
        {
            if (go == null)
            {
                Debug.LogError("请先选择预制体");
                return;
            }
            //var texture = AssetPreview.GetAssetPreview(go) as Texture;
            if (SaveRenderTextureToPNG(go, @"Assets/Image/2.png"))
            {
                Debug.LogError("导出成功");
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    public static void CreatePNG()
    {

    }

    public static bool SaveTextureToPNG(Texture inputTex, string save_file_name)
    {
        RenderTexture temp = RenderTexture.GetTemporary(inputTex.width, inputTex.height, 0, RenderTextureFormat.ARGB32);
        Graphics.Blit(inputTex, temp);
        bool ret = SaveRenderTextureToPNG(temp, save_file_name);
        RenderTexture.ReleaseTemporary(temp);
        return ret;
    }


    public static bool SaveRenderTextureToPNG(RenderTexture rt, string save_file_name)
    {
        RenderTexture prev = RenderTexture.active;
        RenderTexture.active = rt;
        Texture2D png = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
        png.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        byte[] bytes = png.EncodeToPNG();
        string directory = Path.GetDirectoryName(save_file_name);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        FileStream file = File.Open(save_file_name, FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(bytes);
        file.Close();
        Texture2D.DestroyImmediate(png);
        png = null;
        RenderTexture.active = prev;
        return true;
    }
}
