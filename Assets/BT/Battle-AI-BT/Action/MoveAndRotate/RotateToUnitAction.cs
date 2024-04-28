using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 16:44
    //******************************************
    [Name("转向目标")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("设置战斗单位面向目标对象")]
    public class RotateToUnitAction : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> TargetBattleUnit;

        /*
        protected override void OnExecute()
        {
            BattleUnit unit = BattleUnit.value;//blackboard.GetVariable<BattleUnit>("BattleUnit").value;
            BattleUnit target = TargetBattleUnit.value;//blackboard.GetVariable<BattleUnit>("TargetBattleUnit").value;
            var moveComponent = unit.GetComponent<MoveComponent>();
            var targetPos = target.GetComponent<MoveComponent>().Position;
            var unitPos = unit.GetComponent<MoveComponent>().Position;
            var dir = (targetPos - unitPos).normalized;
            dir.y = 0;
            moveComponent.SetDir(dir);
            EndAction(true);
        }
        */
    }
}