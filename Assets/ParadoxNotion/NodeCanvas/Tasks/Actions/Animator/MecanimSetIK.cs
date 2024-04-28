﻿using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Set IK")]
    [Category("Animator")]
    public class MecanimSetIK : ActionTask<Animator>
    {
        [Name("IK目标")]
        public AvatarIKGoal IKGoal;
        [RequiredField]
        [Name("目标物体")]
        public BBParameter<GameObject> goal;
        [Name("权重")]
        public BBParameter<float> weight;

        protected override string info {
            get { return "Set '" + IKGoal + "' " + goal; }
        }

        protected override void OnExecute() {
            router.onAnimatorIK += OnAnimatorIK;
        }

        protected override void OnStop() {
            router.onAnimatorIK -= OnAnimatorIK;
        }

        void OnAnimatorIK(ParadoxNotion.EventData<int> msg) {
            agent.SetIKPositionWeight(IKGoal, weight.value);
            agent.SetIKPosition(IKGoal, goal.value.transform.position);
            EndAction();
        }
    }
}