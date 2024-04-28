
using UnityEditor;
using UnityEngine;

public class EditorAnimatorCtrl
{
    /// <summary>
    /// 滑动杆的当前时间
    /// </summary>
    public float m_CurTime
    {
        get
        {
            if (mGetAnimProgress == null)
                return 0;

            return mGetAnimProgress.Invoke();
        }
        set
        {

            mSetAnimProgress?.Invoke(value);
        }
    }

    /// <summary>
    /// 是否已经烘培过
    /// </summary>
    public bool m_HasBake;

    /// <summary>
    /// 当前是否是预览播放状态
    /// </summary>
    private bool m_Playing;

    /// <summary>
    /// 当前运行时间
    /// </summary>
    private float m_RunningTime;

    /// <summary>
    /// 上一次系统时间
    /// </summary>
    private double m_PreviousTime;

    /// <summary>
    /// 总的记录时间
    /// </summary>
    private float m_RecorderStopTime;

    /// <summary>
    /// 滑动杆总长度
    /// </summary>
    public float m_Duration = 30f;
    const float frameRate = 30f;


    public Animator animator;

    //public SkillObjectData_Edit editObj;


    System.Func<float> mGetAnimProgress;
    System.Action<float> mSetAnimProgress;
    



    public void OnEnable()
    {
        m_PreviousTime = EditorApplication.timeSinceStartup;
        EditorApplication.update += inspectorUpdate;

        //var anim = UnityEditor.AssetDatabase.LoadAssetAtPath<Animator>("Assets/Editor/BattleEditor/PlayerRoleAnim");
        //animator = anim;
    }

    public void OnDisable()
    {
        EditorApplication.update -= inspectorUpdate;
    }  


    public float ChangeAnim(AnimationClip anim, System.Func<float> getAnimProgress, System.Action<float> setAnimProgress)
    {
        if(animator == null)
        {
            return 0;
        }

        RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;

        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        overrideController["anim"] = anim;
        m_Duration = anim.length;
        m_HasBake = false;
        mGetAnimProgress = getAnimProgress;
        mSetAnimProgress = setAnimProgress;
        return m_Duration;
    }

    int frameCount;
    /// <summary>
    /// 烘培记录动画数据
    /// </summary>
    public void bake()
    {
        if (m_HasBake)
        {
            return;
        }

        if (animator == null)
        {
            return;
        }

        frameCount = (int)((m_Duration * frameRate) + 2);
        animator.Rebind();
        animator.StopPlayback();
        animator.recorderStartTime = 0;

        // 开始记录指定的帧数
        animator.StartRecording(frameCount);

        for (var i = 0; i < frameCount - 1; i++)
        {
            // 这里可以在指定的时间触发新的动画状态
            //if (i == 200)
            //{
            //    animator.SetTrigger("Dance");
            //}

            // 记录每一帧
            animator.Update(1.0f / frameRate);
        }
        // 完成记录
        animator.StopRecording();

        // 开启回放模式
        animator.StartPlayback();
        m_HasBake = true;
        m_RecorderStopTime = animator.recorderStopTime;
    }

    /// <summary>
    /// 进行预览播放
    /// </summary>
    public void play()
    {
        if ( animator == null)
        {
            return;
        }

        bake();
        m_RunningTime = 0f;
        m_Playing = true;
    }

    /// <summary>
    /// 停止预览播放
    /// </summary>
    public void stop()
    {
        if ( animator == null)
        {
            return;
        }

        m_Playing = false;
        m_CurTime = 0f;
    }

    /// <summary>
    /// 预览播放状态下的更新
    /// </summary>
    private void update()
    {
        if ( animator == null)
        {
            return;
        }

        if (m_RunningTime >= m_RecorderStopTime)
        {
            stop();
            return;
        }

        // 设置回放的时间位置
        animator.playbackTime = m_RunningTime;
        animator.Update(0);
        m_CurTime = m_RunningTime;

    }

    void manualUpdate()
    {
        if ( animator == null)
        {
            return;
        }

        animator.playbackTime = m_CurTime;
        animator.Update(0);
    }

    private void inspectorUpdate()
    {
        var delta = EditorApplication.timeSinceStartup - m_PreviousTime;
        m_PreviousTime = EditorApplication.timeSinceStartup;

        if (animator == null)
            return;

        if (m_Playing)
        {
            m_RunningTime = Mathf.Clamp(m_RunningTime + (float)delta, 0f, m_Duration);
            update();
        }
        else
        {
            manualUpdate();
        }
    }
}
