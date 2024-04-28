using System.Collections.Generic;
using System.Text;
using KLFramework.IOC;
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
    // @Date: 2021-09-02 20:25
    //******************************************
    [Name("伙伴释放技能")]
    [Category("_昆仑/行为任务")]
    [Description("伙伴释放技能")]
    public class PartnerTrySkillAction : ActionTask
    {
        [Name("搜索距离")]
        public BBParameter<float> SearchDistance = -1;
        [Name("伙伴对象")]
        public BBParameter<BattleUnit> Partner;
        [Name("上下文本")]
        public BBParameter<IBeanContext> BeanContext;
        
        
        public enum Result
        {
            DoNothing,
            ReturnTrue,
            ReturnFalse
        }

        [Name("技能索引")]
        public BBParameter<int> SkillIndex;

        [Name("释放中返回结果")]
        public BBParameter<Result> ResultOnCasting = Result.DoNothing;
        [Name("释放失败返回结果")]
        public BBParameter<Result> ResultOnCastFail = Result.ReturnFalse;

        /*
        class CastInfo
        {
            private bool _Casting;
            //private float _Time;
            private BattleUnit _Owner;

            public CastInfo(BattleUnit owner)
            {
                _Owner = owner;
            }

            public bool IsCasting()
            {
                if (_Casting)
                {
                    //_Time -= Time.deltaTime;
                    //if (_Time <= 0)
                    if (_Owner.StateCom.CanCastNormalOrActiveSkill())
                    {
                        _Casting = false;
                    }
                }

                return _Casting;
            }

            public void Casting()
            {
                _Casting = true;
            }

            public void EndCasting()
            {
                _Casting = false;
            }

            //public void SetCastTime(float time)
            //{
            //    Casting();
            //    _Time = time;
            //}
        }
        
        private Dictionary<BattleUnit, CastInfo> _CastInfos = new Dictionary<BattleUnit, CastInfo>();
        private BattleUnit _CharseUnit;
        
        #if UNITY_EDITOR
        private StringBuilder _StringBuilder = new StringBuilder();
        private string _Info;
        #endif
        
        protected override string info
        {
            get
            {
                #if UNITY_EDITOR
                _StringBuilder.Clear();
                foreach (var castInfo in _CastInfos)
                {
                    _StringBuilder.Append(castInfo.Key.ID).Append(":").Append(castInfo.Value.IsCasting()).Append(",");
                }
                return "Cast Skill#" + SkillIndex + ", _Info=" + (_Info ?? "") + "\n castInfo=" + _StringBuilder;
                #endif
                return "Cast Skill#" + SkillIndex;
            }
        }

        private void _EndAction(bool casting)
        {
            Result testResult;
            if (casting)
            {
                testResult = ResultOnCasting.value;
            }
            else
            {
                testResult = ResultOnCastFail.value;
            }
            switch (testResult)
            {
                case Result.DoNothing:
                    break;
                case Result.ReturnFalse:
                    EndAction(false);
                    break;
                case Result.ReturnTrue:
                    EndAction(true);
                    break;
                default:
                    Debug.LogError("End action with unknow return result `" + testResult + "`");                        
                    break;
            }
        }

        protected override void OnExecute()
        {
            TryCasting();
        }
        
        private void _Record(string info)
        {
            #if UNITY_EDITOR
            info = "[" + Time.frameCount + "] " + info;
            //Debug.LogError(info);
            _Info = info;
            #endif
        }

        protected void TryCasting()
        {
            var battleUnit = Partner.value;
            var skills = battleUnit.CreateInfo.SkillDatas;
            var configSkill = skills[SkillIndex.value];

            if (_IsCastingSkill(battleUnit))
            {
                _Record("casting skill");
                _EndAction(true);
                return;
            }
            
            if (configSkill == null)
            {
                _Record("no skill");
                _EndAction(false);
                return;
            }

            if (Partner.value.SkillCom.CheckSkillCDState(configSkill.SkillID))
            {
                _Record("CDing " + configSkill.SkillID);
                _EndAction(false);
                return;
            }

            var unitService = BeanContext.value.FindObjectOfType<UnitService>();
            BattleUnit needRotateToTarget;
            BattleUnit needMoveToTarget;
            bool hasTargetInDistance = false;
            float searchDistance = SearchDistance.value;
            if (searchDistance > 0)
            {
                hasTargetInDistance = unitService.SelectTargetInShape(battleUnit, configSkill.Shape, out needRotateToTarget, searchDistance, out needMoveToTarget);    
            }
            else
            {
                needMoveToTarget = null;
                hasTargetInDistance = unitService.SelectTargetInShape(battleUnit, configSkill.Shape, out needRotateToTarget);
            }

            if (!hasTargetInDistance && needRotateToTarget == null && needMoveToTarget == null)
            {
                _Record("No target " + configSkill.SkillID);
                _EndAction(false);
                return;
            }
            
            _Casting(battleUnit);
            
            if (hasTargetInDistance)
            {
                if (needRotateToTarget != null)
                {
                    // Need rotate
                    BattleUnitUtils.RotateTo(battleUnit, needRotateToTarget);
                }
                _CastSkill(configSkill, battleUnit);
                _EndAction(true);
                _Record("Cast in distance " + configSkill.SkillID);
                return;
            }
            
            
            _CharseUnit = needMoveToTarget;
            
            _Record("Charsing " + configSkill.SkillID);
            _EndAction(true);
        }

        protected override void OnUpdate()
        {
            var battleUnit = Partner.value;
            if (!_IsCastingSkill(battleUnit))
            {
                _Record("No casting");
                _EndAction(false);
                return;
            }

            if (_CharseUnit == null)
            {
                _EndAction(false);
                return;
            }

            if (_CharseUnit.IsDead())
            {
                _CharseUnit = null;
                battleUnit.FsmCom.TryChangeToNewState(UnitStateDefine.Idle);
                battleUnit.MoveCom.StopMove();
                _Record("Dead - recast");
                TryCasting();
                _EndAction(false);
                return;
            }
                    
            var skills = battleUnit.CreateInfo.SkillDatas;
            var configSkill = skills[SkillIndex.value];
            var skillDistance = configSkill.Shape.MaxDistance();
            var skillSqrDistance = skillDistance * skillDistance;
            if ((_CharseUnit.Position - battleUnit.Position).sqrMagnitude <= skillSqrDistance)
            {
                _CharseUnit = null;
                battleUnit.FsmCom.TryChangeToNewState(UnitStateDefine.Idle);
                battleUnit.MoveCom.StopMove();
                _Record("Charsed and cast");
                _CastSkill(configSkill, battleUnit);
            }
            else
            {
                battleUnit.FsmCom.TryChangeState(UnitStateDefine.Run);
                battleUnit.MoveCom.MoveInWorld((_CharseUnit.Position - battleUnit.Position).normalized, MoveComponent.STATUS_RUN, b =>{});
                _Record("Moving to target");
            }
            
            _EndAction(true);
        }

        private void _CastSkill(ConfigSkill configSkill, BattleUnit battleUnit)
        {
            if (_IsCastingSkill(battleUnit))
            {
                return;
            }
            

            IBeanContext beanContext = BeanContext.value;
            CommandService commandService = beanContext.FindObjectOfType<CommandService>();
            commandService.CreateSkillCmd(battleUnit, configSkill, CmdPriority.Immediately, (skillConfigStage, stage) =>
            {
                if (stage == SkillStage.Reset || skillConfigStage == SkillConfigStage.CastEnd)
                {
                    _EndCasting(battleUnit);
                }
            });

            _MarkCastingSkill(battleUnit, configSkill);
        }

        private void _MarkCastingSkill(BattleUnit battleUnit, ConfigSkill configSkill)
        {
            _Casting(battleUnit);
            //float time = configSkill.GetSkillEndTime(battleUnit);
            //_CastInfos[battleUnit].SetCastTime(time);
            //_CastInfos[battleUnit].Casting();
        }

        private void _EndCasting(BattleUnit battleUnit)
        {
            if (!_CastInfos.ContainsKey(battleUnit))
            {
                return;
            }
            
            _CastInfos[battleUnit].EndCasting();
        }

        private void _Casting(BattleUnit battleUnit)
        {
            CastInfo castInfo; 
            if (_CastInfos.ContainsKey(battleUnit))
            {
                castInfo = _CastInfos[battleUnit];
            }
            else
            {
                castInfo = new CastInfo(battleUnit);
                _CastInfos.Add(battleUnit, castInfo);
            }

            castInfo.Casting();
        }

        private bool _IsCastingSkill(BattleUnit battleUnit)
        {
            if (!_CastInfos.ContainsKey(battleUnit))
            {
                return false;
            }

            return _CastInfos[battleUnit].IsCasting();
        }
        */
    }
}