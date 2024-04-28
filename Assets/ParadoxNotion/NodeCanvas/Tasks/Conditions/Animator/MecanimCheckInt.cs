using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Parameter Int")]
    [Category("Animator")]
    public class MecanimCheckInt : ConditionTask<Animator>
    {

        [RequiredField]
        [Name("参数名称")]
        public BBParameter<string> parameter;
        [Name("对比方式")]
        public CompareMethod comparison = CompareMethod.EqualTo;
        [Name("值")]
        public BBParameter<int> value;

        protected override string info {
            get
            {
                return "Mec.Int " + parameter.ToString() + OperationTools.GetCompareString(comparison) + value;
            }
        }

        protected override bool OnCheck() {
            return OperationTools.Compare((int)agent.GetInteger(parameter.value), (int)value.value, comparison);
        }
    }
}