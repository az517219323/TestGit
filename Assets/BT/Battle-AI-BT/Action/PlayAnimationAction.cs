using System;
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
    [Name("播放动画")]
    [Category("_昆仑/行为任务")]
    [Description("播放动画，动画播放没有完成返回运行中，播完返回成功")]
    public class PlayAnimationAction : PlayAction
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("动画名称")]
        public BBParameter<string> Animation;

        private float _Time;


        protected override bool _OnExecute()
        {
            //var fsmCom = BattleUnit.value.FsmCom;
            //UnitStateDefine unitStateDefine = (UnitStateDefine) Enum.Parse(typeof(UnitStateDefine), Animation.value, true);
            //if (unitStateDefine == null)
            //{
            //    return false;
            //}
            //fsmCom.TryChangeState(unitStateDefine);
            //_Time = BattleUnit.value.AniCom.GetAnimationTimes(Animation.value);
            return true;
        }

        protected override ExeStatus _CheckRunningStatus()
        {
            _Time -= Time.deltaTime;
            if (_Time > 0)
            {
                return ExeStatus.Running;
            }

            return ExeStatus.Succ;
        }
    }
}