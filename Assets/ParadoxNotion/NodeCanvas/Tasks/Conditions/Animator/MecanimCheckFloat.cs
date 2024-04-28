using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Parameter Float")]
    [Category("Animator")]
    public class MecanimCheckFloat : ConditionTask<Animator>
    {

        [RequiredField]
        [Name("参数名称")]
        public BBParameter<string> parameter;
        [Name("比较方式")]
        public CompareMethod comparison = CompareMethod.EqualTo;
        [Name("值")]
        public BBParameter<float> value;

        protected override string info {
            get
            {
                return "Mec.Float " + parameter.ToString() + OperationTools.GetCompareString(comparison) + value;
            }
        }

        protected override bool OnCheck() {

            return OperationTools.Compare((float)agent.GetFloat(parameter.value), (float)value.value, comparison, 0.1f);
        }
    }
}