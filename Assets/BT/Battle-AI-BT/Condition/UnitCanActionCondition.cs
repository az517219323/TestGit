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
    [Name("行为是否可以执行")]
    [Category("_昆仑/条件任务")]
    [Description("判断战斗单位是否可以执行某种行为，或者不能执行某种行为")]
    public class UnitCanActionCondition : ConditionTask
    {
        public enum UActionType
        {
            Move,
            SkillOrAttack
        }

        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("行为类型")]
        public BBParameter<UActionType> ActionType;

        //[Name("是否能执行")]
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