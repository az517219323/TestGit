using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Physics")]
    public class GetLinecastInfo : ActionTask<Transform>
    {

        [RequiredField]
        [Name("目标物体")]
        public BBParameter<GameObject> target;
        [Name("层级遮罩")]
        public BBParameter<LayerMask> layerMask = (LayerMask)( -1 );
        [BlackboardOnly]
        [Name("保存碰撞的物体")]
        public BBParameter<GameObject> saveHitGameObjectAs;
        [BlackboardOnly]
        [Name("保存物体距离")]
        public BBParameter<float> saveDistanceAs;
        [BlackboardOnly]
        [Name("保存物体坐标")]
        public BBParameter<Vector3> savePointAs;
        [BlackboardOnly]
        [Name("保存物体表面的法线")]
        public BBParameter<Vector3> saveNormalAs;

        private RaycastHit hit = new RaycastHit();

        protected override void OnExecute() {

            if ( Physics.Linecast(agent.position, target.value.transform.position, out hit, layerMask.value) ) {
                saveHitGameObjectAs.value = hit.collider.gameObject;
                saveDistanceAs.value = hit.distance;
                savePointAs.value = hit.point;
                saveNormalAs.value = hit.normal;
                EndAction(true);
                return;
            }

            EndAction(false);
        }

        public override void OnDrawGizmosSelected() {
            if ( agent && target.value )
                Gizmos.DrawLine(agent.position, target.value.transform.position);
        }
    }
}