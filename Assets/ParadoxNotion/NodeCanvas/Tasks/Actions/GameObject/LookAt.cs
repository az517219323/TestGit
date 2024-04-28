using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("GameObject")]
    public class LookAt : ActionTask<Transform>
    {

        [RequiredField]
        [Name("看向目标")]
        public BBParameter<GameObject> lookTarget;
        [Name("是否重复")]
        public bool repeat = false;

        protected override string info {
            get { return "LookAt " + lookTarget; }
        }

        protected override void OnExecute() { DoLook(); }
        protected override void OnUpdate() { DoLook(); }

        void DoLook() {
            var lookPos = lookTarget.value.transform.position;
            lookPos.y = agent.position.y;
            agent.LookAt(lookPos);

            if ( !repeat )
                EndAction(true);
        }
    }
}