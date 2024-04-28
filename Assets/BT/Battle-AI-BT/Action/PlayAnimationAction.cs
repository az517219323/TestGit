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
    [Name("���Ŷ���")]
    [Category("_����/��Ϊ����")]
    [Description("���Ŷ�������������û����ɷ��������У����귵�سɹ�")]
    public class PlayAnimationAction : PlayAction
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("��������")]
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