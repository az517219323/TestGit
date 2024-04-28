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
    // @Date: 2021-11-10 11:13
    //******************************************
    [Category("_昆仑/行为任务/位置和旋转")]
    [Name("相对方向")]
    public class RelativeRotation : ActionTask
    {
        [Name("AI主体")]
        public BBParameter<BattleUnit> Owner;
        [Name("本地坐标系下的方向")]
        public BBParameter<Vector3> Direction;
        [Name("得到的世界坐标系下的方向")]
        public BBParameter<Vector3> SetToDirection;
        /*
        protected override void OnExecute()
        {
            var transform = Owner.value.Transform;
            var dir = transform.TransformDirection(Direction.value);
            SetToDirection.value = Quaternion.FromToRotation(Vector3.forward, dir).eulerAngles;
            SetToDirection.value = (Quaternion.Euler(Direction.value) * transform.rotation).eulerAngles;
            EndAction(true);
        }
        */
    }
}