using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Movement/Direct")]
    [Description("Moves the agent away from target per frame without pathfinding")]
    public class MoveAway : ActionTask<Transform>
    {

        [RequiredField]
        [Name("Ŀ������")]
        public BBParameter<GameObject> target;
        [Name("����")]
        public BBParameter<float> speed = 2;
        [Name("ֹͣ�ƶ��ľ���")]
        public BBParameter<float> stopDistance = 3;
        [Name("�ȴ�Action����")]
        public bool waitActionFinish;

        protected override void OnUpdate() {
            if ( ( agent.position - target.value.transform.position ).magnitude >= stopDistance.value ) {
                EndAction();
                return;
            }

            agent.position = Vector3.MoveTowards(agent.position, target.value.transform.position, -speed.value * Time.deltaTime);
            if ( !waitActionFinish ) {
                EndAction();
            }
        }
    }
}