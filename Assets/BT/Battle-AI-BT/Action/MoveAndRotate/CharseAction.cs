using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 17:27
    //******************************************
    [Name("׷��")]
    [Category("_����/��Ϊ����/�ƶ���ת��/׷��")]
    [Description("��Ŀ���ƶ����ƶ������ܷ�Χ��ֹͣ")]
    public class CharseAction : ActionTask
    {
        [Name("����ID�б�")]
        public BBParameter<List<int>> SkillIDList;
        [Name("��������")]
        public BBParameter<int> SkillIndex;
        [Name("�������")]
		[Tooltip("����ʩ������ٷֱ�")]
        public BBParameter<float> DistanceRatio;
        [Name("�Ƿ��ܲ�")]
	    [Tooltip("��-ʹ���ܲ���������-ʹ����·����")]
        public BBParameter<bool> Run;
        [Name("�ƶ��ٶ�")]
	    [Tooltip("-1Ϊʹ�ñ���������")]
        public BBParameter<float> Speed = -1;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> Unit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;

        public enum CharseResult
        {
            Failure,
            Success,
            Running
        }
        [Name("δ׷��ʱ�ý��״̬")]
        public BBParameter<CharseResult> ResultWhileHaveNotCharsed = CharseResult.Running;
        /*
        private string _Info;
        protected override string info => "Charse by " + (Skill.value ? "Skill" : "NormalAttack") + "-" + SkillIndex + " at " + DistanceRatio + " : " + _Info;

         protected override void OnUpdate()
        {
            BattleUnit unit = Unit.value;//blackboard.GetVariable<BattleUnit>("BattleUnit").value;
            BattleUnit target = Target.value;//blackboard.GetVariable<BattleUnit>("TargetBattleUnit").value;
            var selfMoveComponent = unit.GetComponent<MoveComponent>();
            var targetMoveComponent = target.GetComponent<MoveComponent>();
            float distance = Vector3.Distance(selfMoveComponent.Position, targetMoveComponent.Position);

            var battleUnit = unit;
            var skills = Skill.value ? battleUnit.CreateInfo.SkillDatas : battleUnit.CreateInfo.NormalAttackDatas;
            float harmRange = skills[SkillIndex.value].SkillRadius;
            if (distance <= harmRange * DistanceRatio.value)
            {
                #if UNITY_EDITOR
                _Info = Time.frameCount + " stop charse";
                //Debug.Log("Stop move " + _Info + " " + unit);
                #endif
                selfMoveComponent.StopMove();
                EndAction(true);
                return;
            }

            Vector3 moveWorldDir = (targetMoveComponent.Position - selfMoveComponent.Position).normalized;
            moveWorldDir = Vector3.Scale(moveWorldDir, new Vector3(1, 0, 1));

            bool run = Run == null ? false : Run.value;
            selfMoveComponent.MoveInWorld(moveWorldDir, run ? MoveComponent.STATUS_RUN : MoveComponent.STATUS_WALK, null, target, Speed == null ? -1 : Speed.value);
            var state = run ? UnitStateDefine.Run : UnitStateDefine.Walk;
            unit.GetComponent<FsmComponent>().TryChangeState(state);
            
            
            #if UNITY_EDITOR
            _Info = Time.frameCount + " charsing";
            //Debug.Log("Moving " + _Info + " " + unit);
            #endif

            switch (ResultWhileHaveNotCharsed.value)
            {
                case CharseResult.Failure:
                    EndAction(false);
                    break;
                case CharseResult.Running:
                    break;
                case CharseResult.Success:
                    EndAction(true);
                    break;
                default:
                    Debug.LogError("Unknow charse result type `" + ResultWhileHaveNotCharsed + "`");
                    break;
            }
        }
        */
    }
}