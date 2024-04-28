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
    // @Date: 2021-09-29 10:45
    //******************************************
    [Name("单位追击")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("如果已经冲到技能范围内或者绝对距离内，停止移动,返回成功")]
    public class XUnitCharseAction : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> Unit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;

        [Name("是否使用技能范围")]
        public BBParameter<bool> Skill = true;
        [Name("技能索引")]
        public BBParameter<int> SkillIndex;
        [Name("距离系数")]
        public BBParameter<float> DistanceRatio;

        [Name("使用绝对距离")]
        public bool UseAbsoluteDistance = false;
        [Name("距离值")]
        public BBParameter<float> Distance;

        [Name("是否在距离内")]
        public BBParameter<bool> InDistance;

        [Name("是否跑步移动")]
        public BBParameter<bool> Run;

        [Name("是否在范围内才结束")]
        public bool EndUntilInDistance = true;

        /*
        protected override void OnExecute()
        {
            BattleUnit unit = Unit.value;
            BattleUnit target = Target.value;
            var selfMoveComponent = unit.GetComponent<MoveComponent>();
            var targetMoveComponent = target.GetComponent<MoveComponent>();
            float distance = Vector3.Distance(selfMoveComponent.Position, targetMoveComponent.Position);

            float compareDistance = 0;
            if (UseAbsoluteDistance)
            {
                compareDistance = Distance.value;
            }
            else
            {
                var skills = Skill.value ? unit.CreateInfo.SkillDatas : unit.CreateInfo.NormalAttackDatas;
                compareDistance = skills[SkillIndex.value].SkillRadius * DistanceRatio.value;
            }
            
            if (distance <= compareDistance)
            {
                _SetInDistance(true);
                selfMoveComponent.StopMove();
                EndAction(true);
                return;
            }
            
            _SetInDistance(false);

            Vector3 moveWorldDir = (targetMoveComponent.Position - selfMoveComponent.Position).normalized;
            
            if (Run.value)
            {
                selfMoveComponent.MoveInWorld(moveWorldDir, MoveComponent.STATUS_RUN, null, target);
                unit.GetComponent<FsmComponent>().TryChangeState(UnitStateDefine.Run);
            }
            else
            {
                selfMoveComponent.MoveInWorld(moveWorldDir, MoveComponent.STATUS_WALK, null, target);
                unit.GetComponent<FsmComponent>().TryChangeState(UnitStateDefine.Walk);
            }
            
            if (!EndUntilInDistance)
            {
                EndAction(true);
                return;
            }
        }

        private void _SetInDistance(bool inDistance)
        {
            if (InDistance != null)
            {
                InDistance.value = inDistance;
            }
        }
        */
    }
}