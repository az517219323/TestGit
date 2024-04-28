using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Input (Legacy System)")]
    public class GetInputAxis : ActionTask
    {
        [Name("X÷·")]
        public BBParameter<string> xAxisName = "Horizontal";
        [Name("Y÷·")]
        public BBParameter<string> yAxisName;
        [Name("Z÷·")]
        public BBParameter<string> zAxisName = "Vertical";
        [Name("XYZ¿©¥Û±∂ ˝")]
        public BBParameter<float> multiplier = 1;
        [Name("œÚ¡ø¥Ê¥¢")]
        [BlackboardOnly] public BBParameter<Vector3> saveAs;
        [Name("X÷·¥Ê¥¢")]
        [BlackboardOnly] public BBParameter<float> saveXAs;
        [Name("Y÷·¥Ê¥¢")]
        [BlackboardOnly] public BBParameter<float> saveYAs;
        [Name("Z÷·¥Ê¥¢")]
        [BlackboardOnly] public BBParameter<float> saveZAs;

        [Name(" «∑Ò÷ÿ∏¥")]
        public bool repeat;

        protected override void OnExecute() { Do(); }
        protected override void OnUpdate() { Do(); }

        void Do() {

            var x = string.IsNullOrEmpty(xAxisName.value) ? 0 : Input.GetAxis(xAxisName.value);
            var y = string.IsNullOrEmpty(yAxisName.value) ? 0 : Input.GetAxis(yAxisName.value);
            var z = string.IsNullOrEmpty(zAxisName.value) ? 0 : Input.GetAxis(zAxisName.value);

            saveXAs.value = x * multiplier.value;
            saveYAs.value = y * multiplier.value;
            saveZAs.value = z * multiplier.value;
            saveAs.value = new Vector3(x, y, z) * multiplier.value;
            if ( !repeat ) { EndAction(); }
        }
    }
}