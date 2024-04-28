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
    [Name("ս����λ�����ж�")]
    [Category("_����/��������")]
    [Description("�ж�ս����λ��Ŀ�����֮��ľ����Ƿ���������")]
    public class UnitDistanceCondition : ConditionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> Unit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;
        [Name("�ȽϾ���")]
        public BBParameter<float> Distance;
        [Name("�ȽϷ�ʽ")]
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