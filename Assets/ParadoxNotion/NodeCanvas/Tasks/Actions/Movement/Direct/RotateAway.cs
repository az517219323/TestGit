using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Movement/Direct")]
    [Description("Rotate the agent away from target per frame")]
    public class RotateAway : ActionTask<Transform>
    {

        [RequiredField]
        [Name("Ŀ������")]
        public BBParameter<GameObject> target;
        [Name("��ת�ٶ�")]
        public BBParameter<float> speed = 2;
        [SliderField(1, 180)]
        [Name("ֹͣ��ת�ĽǶȲ�")]
        public BBParameter<float> angleDifference = 5;
        [Name("��ת��")]
        public BBParameter<Vector3> upVector = Vector3.up;
        [Name("�ȴ�Action����")]
        public bool waitActionFinish;

        protected override void OnUpdate() {
            if ( Vector3.Angle(target.value.transform.position - agent.position, -agent.forward) <= angleDifference.value ) {
                EndAction();
                return;
            }

            var dir = target.value.transform.position - agent.position;
            agent.rotation = Quaternion.LookRotation(Vector3.RotateTowards(agent.forward, dir, -speed.value * Time.deltaTime, 0), upVector.value);
            if ( !waitActionFinish ) {
                EndAction();
            }
        }
    }
}