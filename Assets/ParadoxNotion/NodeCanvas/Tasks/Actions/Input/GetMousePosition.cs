using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Input (Legacy System)")]
    public class GetMousePosition : ActionTask
    {
        [Name("保存至")]
        [BlackboardOnly] public BBParameter<Vector3> saveAs;
        [Name("是否重复")]
        public bool repeat;

        protected override void OnExecute() { Do(); }
        protected override void OnUpdate() { Do(); }

        void Do() {
            saveAs.value = Input.mousePosition;
            if ( !repeat ) { EndAction(); }
        }
    }
}