using NodeCanvas.Framework;
using ParadoxNotion;
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
    [Name("״̬�ж�")]
    [Category("_����/��������")]
    [Description("��ʱδ�ã���UnitCanActionCondition���")]
    public class UnitStatusCondition : ConditionTask
    {
        public BBParameter<BattleUnit> BattleUnit;
        public bool Skilling;

        /*
        protected override string info {
            get
            {
                string s = "";
                if (Skilling)
                {
                    s = _AddStatus(s, "Skill");
                }
                return s;
            }
        }

        private string _AddStatus(string s, string label)
        {
            if (string.IsNullOrEmpty(s))
            {
                s = "Check " + label;
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
            if (Skilling)
            {
                var skillCom = battleUnit.SkillCom;
                return skillCom.GetCurSkillData() != null && !skillCom.CanBreakCurrentSkill();
            }

            return false;
        }
        */
    }
}