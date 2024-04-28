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
    [Name("技能范围判断")]
    [Category("_昆仑/条件任务")]
    [Description("判断目标对象是否在当前战斗单位的技能（普通攻击）范围内")]
    public class UnitTargetInRangeCondition : ConditionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;
        [Name("是否技能")]
        public bool Skill;
        [Name("技能或者普攻击索引")]
        public BBParameter<int> Index;
        [Name("距离缩放系数")]
        public BBParameter<float> Ratio = 1;
        
        /*
        protected override string info {
            get
            {
                return (Skill ? "Skill" : "NormalAttack") + " " + Index + $" Ratio(${Ratio})";
            }
        }

        protected override bool OnCheck() 
        {
            var battleUnit = BattleUnit.value;

            var skillDatas = Skill ? battleUnit.CreateInfo.SkillDatas : battleUnit.CreateInfo.NormalAttackDatas;
            var skillData = skillDatas[Index.value];
            float needDistance = skillData.Shape.MaxDistance() * Ratio.value;
            var distance = Vector3.Distance(BattleUnit.value.Position, Target.value.Position);
            return distance <= needDistance;
        }
        */
    }
}