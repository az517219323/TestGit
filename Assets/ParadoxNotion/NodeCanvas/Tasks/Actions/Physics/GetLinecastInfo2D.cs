using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Physics")]
    public class GetLinecastInfo2D : ActionTask<Transform>
    {

        [RequiredField]
        [Name("目标物体")]
        public BBParameter<GameObject> target;
        [Name("层级遮罩")]
        public LayerMask mask = -1;
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

        private RaycastHit2D hit;

        protected override void OnExecute() {

            hit = Physics2D.Linecast(agent.position, target.value.transform.position, mask);

            if ( hit.collider != null ) {
                saveHitGameObjectAs.value = hit.collider.gameObject;
                saveDistanceAs.value = hit.fraction;
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