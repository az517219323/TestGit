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
    [Name("���ܷ�Χ�ж�")]
    [Category("_����/��������")]
    [Description("�ж�Ŀ������Ƿ��ڵ�ǰս����λ�ļ��ܣ���ͨ��������Χ��")]
    public class UnitTargetInRangeCondition : ConditionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;
        [Name("�Ƿ���")]
        public bool Skill;
        [Name("���ܻ����չ�������")]
        public BBParameter<int> Index;
        [Name("��������ϵ��")]
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