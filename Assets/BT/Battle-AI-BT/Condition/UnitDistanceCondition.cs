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
    [Name("战斗单位距离判断")]
    [Category("_昆仑/条件任务")]
    [Description("判断战斗单位和目标对象之间的距离是否满足条件")]
    public class UnitDistanceCondition : ConditionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> Unit;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;
        [Name("比较距离")]
        public BBParameter<float> Distance;
        [Name("比较方式")]
        public CompareMethod CheckType;

        /*
        protected override string info {
            get { return "Distance" + OperationTools.GetCompareString(CheckType) + Distance; }
        }
        
        protected override bool OnCheck() {

            var unitPos = Unit.value.Position;
            var targetPos = Target.value.Position;
            var distance = Vector3.Distance(unitPos, targetPos);
            return OperationTools.Compare(distance, Distance.value, CheckType, 0);
        }
        
        public override void OnDrawGizmosSelected() {
            if (Unit == null || Target == null || Target.value == null || Unit.value == null)
            {
                return;
            }
            var unitPos = Unit.value.Position;
            var targetPos = Target.value.Position;
            Gizmos.DrawLine(unitPos, targetPos);
        }
        */
    }
}