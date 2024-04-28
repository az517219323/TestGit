using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Physics")]
    public class GetLinecastInfo2D : ActionTask<Transform>
    {

        [RequiredField]
        [Name("Ŀ������")]
        public BBParameter<GameObject> target;
        [Name("�㼶����")]
        public LayerMask mask = -1;
        [BlackboardOnly]
        [Name("������ײ������")]
        public BBParameter<GameObject> saveHitGameObjectAs;
        [BlackboardOnly]
        [Name("�����������")]
        public BBParameter<float> saveDistanceAs;
        [BlackboardOnly]
        [Name("������������")]
        public BBParameter<Vector3> savePointAs;
        [BlackboardOnly]
        [Name("�����������ķ���")]
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