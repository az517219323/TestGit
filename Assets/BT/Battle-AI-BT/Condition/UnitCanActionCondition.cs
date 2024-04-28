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
    // @Date: 2021-07-23 18:52
    //******************************************
    [Name("��Ϊ�Ƿ����ִ��")]
    [Category("_����/��������")]
    [Description("�ж�ս����λ�Ƿ����ִ��ĳ����Ϊ�����߲���ִ��ĳ����Ϊ")]
    public class UnitCanActionCondition : ConditionTask
    {
        public enum UActionType
        {
            Move,
            SkillOrAttack
        }

        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("��Ϊ����")]
        public BBParameter<UActionType> ActionType;

        //[Name("�Ƿ���ִ��")]
        //public bool Can;

        /*
        protected override string info {
            get
            {
                string s = "";
                s = _AddStatus(s, (Can ? "Can" : "Cannot") + " " + ActionType);
                return s;
            }
        }

        private string _AddStatus(string s, string label)
        {
            if (string.IsNullOrEmpty(s))
            {
                s = "" + label;
            }
            else
            {
                s += ", " + label;
            }
            return s;
        }

        protected override bool OnCheck() 
        {
            var battleUnit = BattleUnit.value;

            switch (ActionType.value)
            {
                case UActionType.Move:
                    return battleUnit.StateCom.CanMove();
                case UActionType.SkillOrAttack:
                    return battleUnit.StateCom.CanCastNormalOrActiveSkill();
                //return battleUnit.StateCom.CanCastSkill();
                default:
                    Debug.LogError("Unknow ActionType " + ActionType);
                    return false;
            }
        }
        */
    }
}