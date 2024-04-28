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
    [Name("��λ׷��")]
    [Category("_����/��Ϊ����/�ƶ���ת��")]
    [Description("����Ѿ��嵽���ܷ�Χ�ڻ��߾��Ծ����ڣ�ֹͣ�ƶ�,���سɹ�")]
    public class XUnitCharseAction : ActionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> Unit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;

        [Name("�Ƿ�ʹ�ü��ܷ�Χ")]
        public BBParameter<bool> Skill = true;
        [Name("��������")]
        public BBParameter<int> SkillIndex;
        [Name("����ϵ��")]
        public BBParameter<float> DistanceRatio;

        [Name("ʹ�þ��Ծ���")]
        public bool UseAbsoluteDistance = false;
        [Name("����ֵ")]
        public BBParameter<float> Distance;

        [Name("�Ƿ��ھ�����")]
        public BBParameter<bool> InDistance;

        [Name("�Ƿ��ܲ��ƶ�")]
        public BBParameter<bool> Run;

        [Name("�Ƿ��ڷ�Χ�ڲŽ���")]
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