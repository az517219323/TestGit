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
    [Name("追击")]
    [Category("_昆仑/行为任务/移动与转向/追击")]
    [Description("往目标移动，移动到技能范围内停止")]
    public class CharseAction : ActionTask
    {
        [Name("技能ID列表")]
        public BBParameter<List<int>> SkillIDList;
        [Name("技能索引")]
        public BBParameter<int> SkillIndex;
        [Name("距离比例")]
		[Tooltip("技能施法距离百分比")]
        public BBParameter<float> DistanceRatio;
        [Name("是否跑步")]
	    [Tooltip("是-使用跑步动作，否-使用走路动作")]
        public BBParameter<bool> Run;
        [Name("移动速度")]
	    [Tooltip("-1为使用表数据配置")]
        public BBParameter<float> Speed = -1;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> Unit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;

        public enum CharseResult
        {
            Failure,
            Success,
            Running
        }
        [Name("未追到时该结点状态")]
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