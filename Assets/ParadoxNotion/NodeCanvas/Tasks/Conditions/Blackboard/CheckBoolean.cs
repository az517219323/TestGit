using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Reflection;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("✫ Blackboard")]
    [Description("判断 值A与 值B是否相等")]
    public class CheckBoolean : ConditionTask
    {
        [BlackboardOnly]
        public BBParameter<bool> valueA;
        public BBParameter<bool> valueB = true;

        protected override string info {
            get { return valueA + " == " + valueB; }
        }

        protected override bool OnCheck() {
            return valueA.value == valueB.value;
        }
    }
}