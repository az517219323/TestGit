using System.Collections.Generic;
using NodeCanvas.BehaviourTrees;
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
    // @Date: 2021-07-22 11:33
    //******************************************
    [Name("��λCD")]
    [Category("_����/װ��")]
    [Description("")]
    public class UnitCDDecorator : BTDecorator
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("CDֵ")]
        public BBParameter<float> CD;
        [Name("����CD�з���true")]
        public bool ReturnTrueIfNotInCD;
        
        private Dictionary<BattleUnit, float> _CDs = new Dictionary<BattleUnit, float>();
        
        protected override Status OnExecute(Component agent, IBlackboard blackboard) {

            if ( decoratedConnection == null ) {
                return Status.Optional;
            }

            if (_IsNotInCD())
            {
                status = decoratedConnection.Execute(agent, blackboard);
                if ( status == Status.Success )
                {
                    _UpdateCD();
                }

                if (ReturnTrueIfNotInCD)
                {
                    status = Status.Success;
                }
            }
            return status;
        }

        private void _UpdateCD()
        {
            if (_CDs.ContainsKey(BattleUnit.value))
            {
                if (Time.time >= _CDs[BattleUnit.value])
                {
                    _CDs[BattleUnit.value] = Time.time + CD.value;
                }
            }
            else
            {
                _CDs.Add(BattleUnit.value, Time.time + CD.value);
            }
        }

        private bool _IsNotInCD()
        {
            bool notInCD;
            if (_CDs.ContainsKey(BattleUnit.value))
            {
                notInCD = Time.time >= _CDs[BattleUnit.value];
            }
            else
            {
                notInCD = true;
            }
            return notInCD;
        }
    }
}