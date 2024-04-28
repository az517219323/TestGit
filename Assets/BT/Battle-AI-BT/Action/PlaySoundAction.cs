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
    [Name("��������")]
    [Category("_����/��Ϊ����")]
    [Description("��������")]
    public class PlaySoundAction : PlayAction
    {
        [Name("������")]
        public BBParameter<BeanContext> BeanContext;
        [Name("��������")]
        public BBParameter<string> SoundName;
        [Name("�Ƿ�3D")]
        public BBParameter<bool> Is3DSound;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("�Ƿ�ѭ��")]
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