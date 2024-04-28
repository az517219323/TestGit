using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-23 18:52
    //******************************************
    [Category("_昆仑/条件任务")]
    [Name("距离判断")]
    [Description("以米为单位，放大10000倍")]
    public class DistanceCondition : ConditionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> Unit;
        [Name("目标单位")]
        public BBParameter<BattleUnit> Target;
        [Name("比较距离")]
        public BBParameter<float> Distance;
        [Name("比较方式")]
        public CompareMethod CheckType;
        /*
        protected override string info {
            get { return "距离" + OperationTools.GetCompareString(CheckType) + Distance; }
        }
        
        protected override bool OnCheck() {

            var p0 = Unit.value.Position;
            var p1 = Target.value.Position;
            var distance = Vector3.Distance(p0, p1);
            return OperationTools.Compare(distance, Distance.value, CheckType, 0);
        }
        
        public override void OnDrawGizmosSelected() {
            if ( Unit != null && Target != null && Unit.value != null && Target.value != null) 
            {
                Gizmos.DrawLine(Unit.value.Position, Target.value.Position);
            }
        }
        */
    }
}