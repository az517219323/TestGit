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
    [Name("ת��Ŀ��")]
    [Category("_����/��Ϊ����/�ƶ���ת��")]
    [Description("����ս����λ����Ŀ�����")]
    public class RotateToUnitAction : ActionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("Ŀ�����")]
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