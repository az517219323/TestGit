using System.Collections.Generic;
using DefaultNamespace;
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
    // @Date: 2021-08-04 17:12
    //******************************************
    [Name("单位左右移动")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("管理一组unit的侧移")]
    public class UnitSideMoveAction : ActionTask
    {
        [Name("最小移动时间")]
        public BBParameter<float> MinMoveTime;
        [Name("最大移动时间")]
        public BBParameter<float> MaxMoveTime;
        //public BBParameter<float> InnerRange = 2.5f;
        //public BBParameter<float> OutterRange = 5f;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标单位")]
        public BBParameter<BattleUnit> TargetBattleUnit;
        //public BBParameter<List<BattleUnit>> MovingUnits;

        /*
        class UnitData
        {
            private BattleUnit unit;
            private int _Direction = 1;
            private float _Time = 0;
            private float _MoveTime = -1;
            private MoveComponent _SelfMoveComponent;
            private FsmComponent _FsmComponent;

            public UnitData(BattleUnit unit)
            {
                this.unit = unit;
                _SelfMoveComponent = unit.GetComponent<MoveComponent>();
                _FsmComponent = unit.GetComponent<FsmComponent>();
            }

            public void TryReset(BattleUnit target, float moveTime, int direction)
            {
                if (_Time >= _MoveTime)
                {
                    _MoveTime = moveTime;
                    _Time = 0;
                    _Direction = direction;
                }
            }

            public void Execute(BattleUnit target)
            {
                _Time += Time.deltaTime;
            
                Vector3 moveDir = Vector3.Lerp(new Vector3(_Direction, 0, 0), new Vector3(0, 0, 1), 0.25f).normalized;
                //moveDir = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(_Direction, 0, 0), 0.25f).normalized;
                _SelfMoveComponent.Move(moveDir, MoveComponent.STATUS_WALK, _OnMoveEnd, target, Constant.SIDE_WALK_SPEED * 0.8f);

                if (!_FsmComponent.IsInXState(UnitStateDefine.Walk))
                {
                    _FsmComponent.TryChangeToNewState(UnitStateDefine.Walk, _Direction);
                }
                
                bool end = _Time >= _MoveTime;
                if (end)
                {
                    _SelfMoveComponent.Update(Time.time, Time.deltaTime);
                    _SelfMoveComponent.StopMove();
                }
            }
        
            private void _OnMoveEnd(bool obj)
            {
            }
        }

        private Dictionary<BattleUnit, UnitData> _UnitData = new Dictionary<BattleUnit, UnitData>();

        protected override void OnExecute()
        {
            _TryResetSideMoveData();
            EndAction(true);
        }

        private void _TryResetSideMoveData()
        {
            float moveTime = Random.Range(MinMoveTime.value, MaxMoveTime.value);
            int direction = Random.Range(0, 1f) < 0.5f ? -1 : 1;
            
            UnitData unitData;
            if (_UnitData.ContainsKey(BattleUnit.value))
            {
                unitData = _UnitData[BattleUnit.value];
            }
            else
            {
                unitData = new UnitData(BattleUnit.value);
                _UnitData.Add(BattleUnit.value, unitData);
            }

            var target = TargetBattleUnit.value;
            unitData.TryReset(target, moveTime, direction);
            unitData.Execute(target);
        }
        */
    }

}