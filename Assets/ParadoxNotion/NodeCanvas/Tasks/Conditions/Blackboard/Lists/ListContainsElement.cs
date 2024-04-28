using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("✫ Blackboard/Lists")]
    [Description("Check if an element is contained in the target list")]
    public class ListContainsElement<T> : ConditionTask
    {

        [RequiredField]
        [BlackboardOnly]
        [Name("目标List")]
        public BBParameter<List<T>> targetList;
        [Name("检查元素")]
        public BBParameter<T> checkElement;

        protected override string info {
            get { return targetList + " contains " + checkElement; }
        }

        protected override bool OnCheck() {
            return targetList.value.Contains(checkElement.value);
        }
    }
}