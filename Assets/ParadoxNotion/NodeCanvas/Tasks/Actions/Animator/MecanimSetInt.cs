using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Set Parameter Integer")]
    [Category("Animator")]
    [Description("You can either use a parameter name OR hashID. Leave the parameter name empty or none to use hashID instead.")]
    public class MecanimSetInt : ActionTask<Animator>
    {

        [Name("参数名称")]
        public BBParameter<string> parameter;
        [Name("参数HashID")]
        public BBParameter<int> parameterHashID;
        [Name("设置参数值")]
        public BBParameter<int> setTo;

        protected override string info {
            get { return string.Format("Mec.SetInt {0} to {1}", string.IsNullOrEmpty(parameter.value) && !parameter.useBlackboard ? parameterHashID.ToString() : parameter.ToString(), setTo); }
        }

        protected override void OnExecute() {
            if ( !string.IsNullOrEmpty(parameter.value) ) {
                agent.SetInteger(parameter.value, setTo.value);
            } else {
                agent.SetInteger(parameterHashID.value, setTo.value);
            }
            EndAction();
        }
    }
}