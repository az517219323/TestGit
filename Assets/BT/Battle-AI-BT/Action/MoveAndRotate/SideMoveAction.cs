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
    [Name("左右移动")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("战斗单位相对于目标单位左右移动")]
    public class SideMoveAction : ActionTask
    {
        [Name("随机最小时间")]
        public BBParameter<float> MinMoveTime;
        [Name("随机最大时间")]
        public BBParameter<float> MaxMoveTime;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> TargetBattleUnit;
        
        private int _Direction = 1;
        private float _Time = 0;
        private float _MoveTime;

        /*
        protected override void OnExecute()
        {
            _MoveTime = Random.Range(MinMoveTime.value, MaxMoveTime.value);
            _Time = 0;
            _Direction = Random.Range(0, 1f) < 0.5f ? -1 : 1;
        }
        
        protected override void OnUpdate()
        {
            
            _Time += Time.deltaTime;
        
            BattleUnit unit = BattleUnit.value;//blackboard.GetVariable<BattleUnit>("BattleUnit").value;
            BattleUnit target = TargetBattleUnit.value;//blackboard.GetVariable<BattleUnit>("TargetBattleUnit").value;
            
            var selfMoveComponent = unit.GetComponent<MoveComponent>();
            Vector3 moveDir = Vector3.Lerp(new Vector3(_Direction, 0, 0), new Vector3(0, 0, 1), 0.25f).normalized;
            selfMoveComponent.Move(moveDir, MoveComponent.STATUS_RUN, _OnMoveEnd, target, Constant.SIDE_WALK_SPEED);
            unit.GetComponent<FsmComponent>().TryChangeState(UnitStateDefine.Walk, _Direction);
            bool end = _Time >= _MoveTime;
            
            if (end)
            {
                selfMoveComponent.Update(Time.time, Time.deltaTime);
                selfMoveComponent.StopMove();
                EndAction(true);
            }
        }
        
        private void _OnMoveEnd(bool obj)
        {
        }
        */
    }
}