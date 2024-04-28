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
    // @Date: 2021-07-29 16:44
    //******************************************
    [Name("转向方向")]
    [Category("_昆仑/行为任务/移动与转向")]
    [Description("转向指定方向")]
    public class RotateToDirAction : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("转向的方向")]
        public BBParameter<Vector3> Dir;
        /*
        protected override void OnExecute()
        {
            BattleUnit unit = BattleUnit.value;
            var moveComponent = unit.GetComponent<MoveComponent>();
            var rotation = Quaternion.Euler(Dir.value);
            moveComponent.Rotation = rotation;
            EndAction(true);
        }
        */
    }
}