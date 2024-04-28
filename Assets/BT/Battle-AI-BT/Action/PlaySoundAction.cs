using System;
using KLFramework.IOC;
//using KLGame.OP.Plot;
//using KLGame.OP.Sound;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-17 00:07
    //******************************************
    [Name("播放声音")]
    [Category("_昆仑/行为任务")]
    [Description("播放声音")]
    public class PlaySoundAction : PlayAction
    {
        [Name("上下文")]
        public BBParameter<BeanContext> BeanContext;
        [Name("声音名字")]
        public BBParameter<string> SoundName;
        [Name("是否3D")]
        public BBParameter<bool> Is3DSound;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("是否循环")]
        public BBParameter<bool> Loop;
        private bool _Running;
        
        protected override bool _OnExecute()
        {
            //var soundManager = BeanContext.value.FindObjectOfType<SoundManager>();
            //string soundPath = "sounds/" + SoundName.value;
            //var clip = Resources.Load<AudioClip>(soundPath);
            //_Running = true;
            //if (Is3DSound.value)
            //{
            //    soundManager.Play(clip, BattleUnit.value.Position, Loop.value, ()=>_Running = false);
            //}
            //else
            //{
            //    soundManager.Play2D(clip, Loop.value, ()=>_Running = false);
            //}

            return true;
        }

        protected override ExeStatus _CheckRunningStatus()
        {
            if (_Running)
            {
                return ExeStatus.Running;
            }

            return ExeStatus.Succ;
        }
    }
}