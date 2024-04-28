using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Parameter Bool")]
    [Category("Animator")]
    public class MecanimCheckBool : ConditionTask<Animator>
    {

        [RequiredField]
        [Name("参数名称")]
        public BBParameter<string> parameter;
        [Name("值")]
        public BBParameter<bool> value;

        protected override string info {
            get { return "Mec.Bool " + parameter.ToString() + " == " + value; }
        }

        protected override bool OnCheck() {

            return agent.GetBool(parameter.value) == value.value;
        }
    }
}