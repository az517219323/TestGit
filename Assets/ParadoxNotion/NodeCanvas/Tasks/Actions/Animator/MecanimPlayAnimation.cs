using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Play Animation")]
    [Category("Animator")]
    public class MecanimPlayAnimation : ActionTask<Animator>
    {
        [Name("层级索引")]
        public BBParameter<int> layerIndex;
        [RequiredField]
        [Name("状态名称")]
        public BBParameter<string> stateName;
        [SliderField(0, 1)]
        [Name("过渡时间")]
        public float transitTime = 0.25f;
        [Name("是否等待到Action结束")]
        public bool waitUntilFinish;

        private AnimatorStateInfo stateInfo;
        private bool played;

        protected override string info {
            get { return "Anim '" + stateName.ToString() + "'"; }
        }

        protected override void OnExecute() {
            if ( string.IsNullOrEmpty(stateName.value) ) {
                EndAction();
                return;
            }
            played = false;
            var current = agent.GetCurrentAnimatorStateInfo(layerIndex.value);
            agent.CrossFade(stateName.value, transitTime / current.length, layerIndex.value);
        }

        protected override void OnUpdate() {

            stateInfo = agent.GetCurrentAnimatorStateInfo(layerIndex.value);

            if ( waitUntilFinish ) {

                if ( stateInfo.IsName(stateName.value) ) {

                    played = true;
                    if ( elapsedTime >= ( stateInfo.length / agent.speed ) ) {
                        EndAction();
                    }

                } else if ( played ) {

                    EndAction();
                }

            } else {

                if ( elapsedTime >= transitTime ) {
                    EndAction();
                }
            }
        }
    }
}