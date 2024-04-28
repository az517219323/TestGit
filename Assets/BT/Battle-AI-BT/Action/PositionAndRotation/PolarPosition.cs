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
    // @Date: 2021-11-10 14:06
    //******************************************
    [Category("_昆仑/行为任务/位置和旋转")]
    [Name("极坐标")]
    public class PolarPosition : ActionTask
    {
        [Name("AI主体")]
        public BBParameter<BattleUnit> Owner;
        [Name("半径")]
        public BBParameter<float> Radius;
        [Name("旋转角度(度)，从上往下看，增加该值为逆时针旋转。为0时处于Owner的X轴。")]
        public BBParameter<float> Angle;

        public BBParameter<Vector3> Rotate;
        
        public BBParameter<Vector3> SetToPosition;
        /*
        protected override void OnExecute()
        {
            var transform = Owner.value.Transform;

            var origin = transform.position;
            var sin = Mathf.Sin(Angle.value * Mathf.Deg2Rad);
            var cos = Mathf.Cos(Angle.value * Mathf.Deg2Rad);
            var position = origin + Quaternion.Euler(Rotate.value) * new Vector3(cos * Radius.value, 0, sin * Radius.value);
            
            SetToPosition.value = position;
            EndAction(true);
        }
        */
    }
}