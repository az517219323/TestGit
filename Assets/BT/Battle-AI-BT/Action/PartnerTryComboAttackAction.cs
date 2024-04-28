using System;
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
    [Name("伙伴连击")]
    [Category("_昆仑/行为任务")]
    [Description("伙伴连击")]
    public class PartnerTryComboAttackAction : ActionTask
    {
        public enum Result
        {
            DoNothing,
            ReturnTrue,
            ReturnFalse
        }
        [Name("搜索距离")]
        public BBParameter<float> SearchDistance = -1;
        [Name("伙伴对象")]
        public BBParameter<BattleUnit> Partner;
        [Name("上下文")]
        public BBParameter<IBeanContext> BeanContext;

        [Name("释放中返回结果")]
        public BBParameter<Result> ResultOnCasting = Result.DoNothing;
        [Name("释放失败返回结果")]
        public BBParameter<Result> ResultOnCastFail = Result.ReturnFalse;
        
       // private Dictionary<BattleUnit, CastInfo> _CastInfos = new Dictionary<BattleUnit, CastInfo>();
         
        /*
        #if UNITY_EDITOR
        private string _Infos;
        protected override string info
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var castInfo in _CastInfos)
                {
                    stringBuilder.Append(castInfo.Key.ID).Append(":{").Append(castInfo.Value).Append("},");
                }
                return "Normal Attack:" + (_Infos ?? "")  + " - " + stringBuilder;
            }
        }
        #else 
        protected override string info => "Cast Normal Attack";
        #endif

        private void _RecordInfo(string info)
        {
            #if UNITY_EDITOR
            _Infos = info;
            Debug.LogError(_Infos);
            #endif
        }

        protected override void OnUpdate()
        {
            var battleUnit = Partner.value;

            if (_IsCastingSkill(battleUnit))
            {
                _EndAction(true);
                return;
            }

            if (_TryCasting(battleUnit))
            {
                _EndAction(true);
            }
            else
            {
                _EndAction(false);
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

            //Debug.LogError("End Action casting=" + casting);

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

        private bool _TryCasting(BattleUnit battleUnit)
        {;
            CastInfo castInfo; 
            if (_CastInfos.ContainsKey(battleUnit))
            {
                castInfo = _CastInfos[battleUnit];
            }
            else
            {
                castInfo = new CastInfo(battleUnit, BeanContext.value, SearchDistance.value, (b) =>
                {
                    _EndAction(b);
                });
                _CastInfos.Add(battleUnit, castInfo);
            }
            return castInfo.TryCasting();
        }

        private bool _IsCastingSkill(BattleUnit battleUnit)
        {
            if (!_CastInfos.ContainsKey(battleUnit))
            {
                return false;
            }

            return _CastInfos[battleUnit].UpdateRunning();
        }
        
        

        class CastInfo
        {
#if UNITY_EDITOR
            private string _Infos;
#endif

            private void _RecordInfo(string info)
            {
#if UNITY_EDITOR
                info = "[" + Time.frameCount + "]" + info;
                _Infos = info;
                //UnityEngine.Debug.LogError("<color=#FFFF00FF>" + info + "</color>");
#endif
            }

            public override string ToString()
            {
                #if UNITY_EDITOR
                return _Infos;
                #endif
                return base.ToString();
            }

            private int _Index;
            private bool _WaitNextRound;
            private bool _Running;
            private BattleUnit _Unit;
            private IBeanContext _BeanContext;
            private float _SearchDistance;
            private BattleUnit _CharseUnit;
            private Action<bool> _OnFinish;
            
            public CastInfo(BattleUnit unit, IBeanContext beanContext, float searchDistance, Action<bool> onFinish)
            {
                _Unit = unit;
                _BeanContext = beanContext;
                _SearchDistance = searchDistance;
                _OnFinish = onFinish;
            }

            public bool UpdateRunning()
            {
                if (_Casting)
                {
                    if (_Unit.StateCom.CanCastNormalOrActiveSkill())
                    {
                        _Casting = false;
                        SkillCount--;
                        //Debug.LogError("FinishSkill SkillCount=" + SkillCount);
                        TryNext();
                    }
                }

                if (_Casting)
                {
                    return true;
                }

                if (_CharseUnit != null)
                {
                    if (_CharseUnit.IsDead())
                    {
                        _RecordInfo("Charsing unit is dead");
                        _CharseUnit = null;
                        _Unit.FsmCom.TryChangeToNewState(UnitStateDefine.Idle);
                        _Unit.MoveCom.StopMove();
                        if (!TryCasting())
                        {
                            //Debug.LogError("Fail to try casting");
                            //_Running = false;
                        }
                        //Debug.LogError("Succ try casting");
                    }
                    else
                    {
                        var skills = _Unit.CreateInfo.NormalAttackDatas;
                        var configSkill = skills[_Index];
                        var skillDistance = configSkill.Shape.MaxDistance();
                        var skillSqrDistance = skillDistance * skillDistance;
                        if ((_CharseUnit.Position - _Unit.Position).sqrMagnitude <= skillSqrDistance)
                        {
                            _RecordInfo("Stop moving and cast");
                            _Unit.FsmCom.TryChangeToNewState(UnitStateDefine.Idle);
                            _Unit.MoveCom.StopMove();
                            _CastSkill(configSkill);
                        }
                        else
                        {
                            _RecordInfo("Keep moving to target");
                            _Unit.FsmCom.TryChangeState(UnitStateDefine.Run);
                            _Unit.MoveCom.MoveInWorld((_CharseUnit.Position - _Unit.Position).normalized, MoveComponent.STATUS_RUN, b =>{});    
                        }
                        //Debug.LogError("Charse or move");
                    }
                }
                else
                {
                    _RecordInfo("Null target");
                    //_Running = false;
                    // Debug.LogError("Null target");
                }
                return _Running;
            }

            public bool TryCasting()
            {
                bool castSucc = _TryCasting();
                _OnFinish(castSucc);
                return castSucc;
            }

            private bool _TryCasting()
            {
                if (_WaitNextRound)
                {
                    _WaitNextRound = false;
                    _Index = 0;
                    return false;
                }

                var skills = _Unit.CreateInfo.NormalAttackDatas;
                if (_Index >= skills.Count)
                {
                    _RecordInfo("Skill out of range " + _Index);
                    _Running = false;
                    _Index = 0;
                    // _WaitNextRound = true;
                    return false;
                }

                var configSkill = skills[_Index];
            
                var unitService = _BeanContext.FindObjectOfType<UnitService>();
                BattleUnit needRotateToTarget;
                BattleUnit needMoveToTarget;
                bool hasTargetInDistance = false;
                if (_SearchDistance > 0)
                {
                    hasTargetInDistance = unitService.SelectTargetInShape(_Unit, configSkill.Shape, out needRotateToTarget, _SearchDistance, out needMoveToTarget);    
                }
                else
                {
                    needMoveToTarget = null;
                    hasTargetInDistance = unitService.SelectTargetInShape(_Unit, configSkill.Shape, out needRotateToTarget);
                }

                if ((!hasTargetInDistance && needRotateToTarget == null && needMoveToTarget == null) || (!hasTargetInDistance && needMoveToTarget==null))
                {
                    _RecordInfo("Fail to CastSkill " + configSkill.SkillID);
                    _Running = false;
                    _Index = 0;
                    return false;
                }

                _Running = true;

                if (hasTargetInDistance)
                {
                    if (needRotateToTarget != null)
                    {
                        // Need rotate
                        BattleUnitUtils.RotateTo(_Unit, needRotateToTarget);
                    }
                    _CastSkill(configSkill);
                    return true;
                }

                // Need move
                _CharseUnit = needMoveToTarget;
                _RecordInfo("Charse needMoveToTarget=" + needMoveToTarget + ", needRotateToTarget=" + needRotateToTarget + " S=" + configSkill.SkillID);
                return true;
            }

            private static int SkillCount;
            private bool _Casting;

            private void _CastSkill(ConfigSkill configSkill)
            {
                if (_Casting)
                {
                    return;
                }

                _Casting = true;
                _RecordInfo("_CastSkill " + configSkill.SkillID);
                IBeanContext beanContext = _BeanContext;
                CommandService commandService = beanContext.FindObjectOfType<CommandService>();

                SkillCount++;
                //Debug.LogError("CastSkill SkillCount=" + SkillCount);
                commandService.CreateSkillCmd(_Unit, configSkill, CmdPriority.Immediately, (skillConfigStage, stage) =>
                    {
                        //Debug.LogError("stage=" + stage + ", skillConfigStage=" + skillConfigStage);
                        if (stage == SkillStage.Reset || skillConfigStage == SkillConfigStage.CastEnd)
                        {
                            //TODO 移到Update中，先通过时间计算
                            // _Casting = false;
                            // SkillCount--;
                            // Debug.LogError("FinishSkill SkillCount=" + SkillCount);
                            // TryNext();
                        }
                    });
            }

            public void TryNext()
            {
                _Running = false;
                _Index++;
                TryCasting();
            }
        }
        */
    }

}