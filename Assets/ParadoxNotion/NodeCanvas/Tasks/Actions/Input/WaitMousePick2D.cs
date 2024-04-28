using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Input (Legacy System)")]
    public class WaitMousePick2D : ActionTask
    {

        public enum ButtonKeys
        {
            Left = 0,
            Right = 1,
            Middle = 2
        }

        [Name("��갴��")]
        public ButtonKeys buttonKey;
        [Name("�㼶�ڵ�")]
        public LayerMask mask = -1;
        [BlackboardOnly]
        [Name("��������")]
        public BBParameter<GameObject> saveObjectAs;
        [BlackboardOnly]
        [Name("�������")]
        public BBParameter<float> saveDistanceAs;
        [BlackboardOnly]
        [Name("����λ��")]
        public BBParameter<Vector3> savePositionAs;

        private int buttonID;
        private RaycastHit2D hit;

        protected override string info {
            get { return string.Format("Wait Object '{0}' Click. Save As {1}", buttonKey, saveObjectAs); }
        }

        protected override void OnUpdate() {
            buttonID = (int)buttonKey;
            if ( Input.GetMouseButtonDown(buttonID) ) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, mask);
                if ( hit.collider != null ) {
                    savePositionAs.value = hit.point;
                    saveObjectAs.value = hit.collider.gameObject;
                    saveDistanceAs.value = hit.distance;
                    EndAction(true);
                }
            }
        }
    }
}