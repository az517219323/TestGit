using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Input (Legacy System)")]
    public class WaitMousePick : ActionTask
    {

        public enum ButtonKeys
        {
            Left = 0,
            Right = 1,
            Middle = 2
        }

        [Name("鼠标按键")]
        public ButtonKeys buttonKey;
        [Name("层级遮挡")]
        public LayerMask mask = -1;
        [BlackboardOnly]
        [Name("保存物体")]
        public BBParameter<GameObject> saveObjectAs;
        [BlackboardOnly]
        [Name("保存距离")]
        public BBParameter<float> saveDistanceAs;
        [BlackboardOnly]
        [Name("保存位置")]
        public BBParameter<Vector3> savePositionAs;

        private int buttonID;
        private RaycastHit hit;

        protected override string info {
            get { return string.Format("Wait Object '{0}' Click. Save As {1}", buttonKey, saveObjectAs); }
        }

        protected override void OnUpdate() {
            buttonID = (int)buttonKey;
            if ( Input.GetMouseButtonDown(buttonID) ) {
                if ( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask) ) {
                    savePositionAs.value = hit.point;
                    saveObjectAs.value = hit.collider.gameObject;
                    saveDistanceAs.value = hit.distance;
                    EndAction(true);
                }
            }
        }
    }
}