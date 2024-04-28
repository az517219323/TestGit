using KLFramework.IOC;
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
    // @Date: 2021-07-28 11:31
    //******************************************
    [Name("释放技能")]
    [Category("_昆仑/行为任务")]
    [Description("释放技能,根据配置返回结果")]
    public class CastSkillAction : ActionTask
    {
        [Name("检查是否可以释放技能")]
        public bool CheckCanCast;
        [Name("不可释放技能时返回结果")]
        [ShowIf("CheckCanCast", 1)]
        public BBParameter<Result> ResultOnCannotCast = Result.FailOnFaliure;

        [Name("战斗单位")]
		[Tooltip("BattleUnit为AI载体，可以配置其他目标执行技能释放行为")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("上下文")]
		[Tooltip("默认BeanContext")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("技能ID列表")]
        public BBParameter<List<int>> SkillIDList;
        [Name("技能索引")]
        public BBParameter<int> SkillIndex;
        [Name("子技能")]
        public BBParameter<bool> Sub = false;
        [Name("是否转向目标/位置/方向")]
        public BBParameter<bool> RotateTo = false;
        [Name("使用目标")]
        public BBParameter<bool> UseTarget;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;
        [Name("使用位置")]
        public BBParameter<bool> UsePosition;
        [Name("技能位置")]
        public BBParameter<Vector3> SkillPosition;
        [Name("使用方向")]
        public BBParameter<bool> UseDirection;
        [Name("技能方向")]
        public BBParameter<Vector3> SkillDirection;
        [Name("是否检查范围")]
        public bool CheckRange = false;
        [Name("不在范围中返回结果")]
        public BBParameter<Result> ResultNotInRange = Result.FailOnFaliure;

        public enum Result
        {
            SuccessOnFaliure,
            FailOnFaliure
        }

        [Name("失败时返回结果")]
        public BBParameter<Result> ResultType = Result.FailOnFaliure;
        [Name("是否立即结束")]
        public bool EndTrueImmediately = false;

        private float _WaitTime = 0;

        /*
        protected override string info => "Cast " + (Skill.value ? "Skill " : "Normal Attack ") + SkillIndex;

        protected override void OnExecute()
        {
            BattleUnit battleUnit = BattleUnit.value;
            if (CheckCanCast == CheckCanCastSkill.Yes)
            {
                if (!battleUnit.StateCom.CanCastNormalOrActiveSkill())
                {
                    EndAction(ResultOnCannotCast.value == Result.SuccessOnFaliure);
                    return;
                }
            }

            _WaitTime = 0;

            ConfigSkill configSkill = _GetConfigSkill(battleUnit);

            if (configSkill == null)
            {
                EndAction(ResultType.value == Result.SuccessOnFaliure);
                return;
            }

            IBeanContext beanContext = BeanContext.value;
            CommandService commandService = beanContext.FindObjectOfType<CommandService>();

            if (CheckRange && !configSkill.Shape.IsPointIn(battleUnit.Transform, Target.value.Transform))
            {
                EndAction(ResultNotInRange.value == Result.SuccessOnFaliure);
                return;
            }

            if (Sub.value)
            {
                BattleCmdData_Skill battleCmdDataSkill = new BattleCmdData_Skill
                {
                    SkillData = configSkill,
                    HasTargetDirection = UseDirection.value,
                    TargetDirection = SkillDirection == null ? default : SkillDirection.value,
                    HasTargetPosition = UsePosition.value,
                    TargetPoint = SkillPosition == null ? default : SkillPosition.value,
                };
                IBattleSkill skill;
                BattleCmd_Skill.StartSkill(battleCmdDataSkill, battleUnit, (battleSkill, result) =>
                {
                    // if (!EndTrueImmediately)
                    // {
                    //     EndAction(true);    
                    // }
                    battleUnit.SkillCom.RemoveSubSkill(battleSkill);
                }, out skill, battleUnit.SkillCom.CastSubSkill);
            }
            else
            {
                commandService.CreateSkillCmd(_FindTarget, battleUnit, configSkill, CmdPriority.Immediately, _BattleSkillStageChanged);
            }

            if (EndTrueImmediately)
            {
                EndAction(true);
            }
        }

        private void _FindTarget(out bool foundTargetPosition, out Vector3 targetposition, out bool foundTargetDirection, out Vector3 targetdirection)
        {
            foundTargetPosition = UsePosition.value;
            targetposition = SkillPosition.value;
            foundTargetDirection = UseDirection.value;
            targetdirection = SkillDirection.value;
        }

        private ConfigSkill _GetConfigSkill(BattleUnit battleUnit)
        {
            if (SkillIDList.value != null)
            {
                if (SkillIndex.value >= SkillIDList.value.Count)
                {
                    return null;
                }

                var skillID = SkillIDList.value[SkillIndex.value];
                return battleUnit.GlobalContext.FindObjectOfType<GameDataService>().GetSkillData(skillID);
            }

            var skills = Skill.value ? battleUnit.CreateInfo.SkillDatas : battleUnit.CreateInfo.NormalAttackDatas;
            if (SkillIndex.value >= skills.Count)
            {
                return null;
            }

            var configSkill = skills[SkillIndex.value];
            return configSkill;
        }

        protected override void OnUpdate()
        {
            if (_WaitTime > 0 && BattleUnit.value.SkillCom.GetCurSkillData() == null)
            {
                EndAction(true);
            }
            _WaitTime += Time.deltaTime;
        }

        private void _BattleSkillStageChanged(SkillConfigStage skillConfigStage, SkillStage stage)
        {
            if (EndTrueImmediately)
            {
                return;
            }

            // TODO 先通过时间
            // if (stage == SkillStage.CastEnd || stage == SkillStage.Reset || skillConfigStage == SkillConfigStage.CastEnd)
            // {
            //     EndAction(true);
            // }
        }
        */
    }
}