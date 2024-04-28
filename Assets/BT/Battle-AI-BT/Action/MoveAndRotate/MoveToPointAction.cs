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
    // @Date: 2021-11-10 15:03
    //******************************************
    [Name("移动到指定点")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("获取指定范围内的一个随机坐标")]
    public class MoveToPointAction : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标位置")]
        public BBParameter<Vector3> Position;
        [Name("是否行走")]
        public BBParameter<bool> Walk = true;
        [Name("是否转向移动方向")]
        public BBParameter<bool> RotateWithMoveDirection = true;
        [Name("是否等到到达目标才结束该Action")]
        public BBParameter<bool> EndActionUntilReach = false;
        [Name("是否已经移动到目标点")]
        public BBParameter<bool> MoveEnd = false;
        /*
        protected override void OnExecute()
        {
            var battleUnit = BattleUnit.value;
            var moveComponent = battleUnit.MoveCom;

            var moveVector = Position.value - moveComponent.Position;
            bool reach = Mathf.Approximately(moveVector.sqrMagnitude, 0);

            if (!reach)
            {
                var moveDirInWorld = moveVector.normalized;
                moveComponent.MoveInWorld(moveDirInWorld, Walk.value ? MoveComponent.STATUS_WALK : MoveComponent.STATUS_RUN, null);

                if (RotateWithMoveDirection.value)
                {
                    moveComponent.SetForward(moveDirInWorld);
                }

                var fsmComponent = battleUnit.FsmCom;

                if (!fsmComponent.IsInXState(UnitStateDefine.Walk))
                {
                    fsmComponent.TryChangeToNewState(UnitStateDefine.Walk);
                }
            }

            MoveEnd.value = reach;

            if (!EndActionUntilReach.value || reach)
            {
                EndAction(true);    
            }
        }
        */
    }
}