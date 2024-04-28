using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Animation")]
    public class PlayAnimationAdvanced : ActionTask<Animation>
    {

        [RequiredField]
        [Name("����")]
        public BBParameter<AnimationClip> animationClip;
        [Name("����ģʽ")]
        public WrapMode animationWrap;
        [Name("���ģʽ")]
        public AnimationBlendMode blendMode;
        [SliderField(0, 2)]
        [Name("�����ٶ�")]
        public float playbackSpeed = 1;
        [SliderField(0, 1)]
        [Name("���뵭��ʱ��")]
        public float crossFadeTime = 0.25f;
        [Name("���ŷ���")]
        public PlayDirections playDirection = PlayDirections.Forward;
        [Name("������ϲ�λ")]
        public BBParameter<string> mixTransformName;
        [Name("�����㼶")]
        public BBParameter<int> animationLayer;
        [Name("�Ƿ�Ϊ���ж���")]
        public bool queueAnimation;
        [Name("�Ƿ�ȴ�Action����")]
        public bool waitActionFinish = true;

        private string animationToPlay = string.Empty;
        private int dir = -1;
        private Transform mixTransform;

        protected override string info {
            get { return "Anim " + animationClip.ToString(); }
        }

        protected override string OnInit() {
            agent.AddClip(animationClip.value, animationClip.value.name);
            animationClip.value.legacy = true;
            return null;
        }

        protected override void OnExecute() {

            if ( playDirection == PlayDirections.Toggle )
                dir = -dir;

            if ( playDirection == PlayDirections.Backward )
                dir = -1;

            if ( playDirection == PlayDirections.Forward )
                dir = 1;

            agent.AddClip(animationClip.value, animationClip.value.name);
            animationToPlay = animationClip.value.name;

            if ( !string.IsNullOrEmpty(mixTransformName.value) ) {
                mixTransform = FindTransform(agent.transform, mixTransformName.value);
                if ( !mixTransform ) {
                    ParadoxNotion.Services.Logger.LogWarning("Cant find transform with name '" + mixTransformName.value + "' for PlayAnimation Action", LogTag.EXECUTION, this);
                }

            } else {
                mixTransform = null;
            }

            animationToPlay = animationClip.value.name;

            if ( mixTransform ) {
                agent[animationToPlay].AddMixingTransform(mixTransform, true);
            }

            agent[animationToPlay].layer = animationLayer.value;
            agent[animationToPlay].speed = dir * playbackSpeed;
            agent[animationToPlay].normalizedTime = Mathf.Clamp01(-dir);
            agent[animationToPlay].wrapMode = animationWrap;
            agent[animationToPlay].blendMode = blendMode;

            if ( queueAnimation ) {
                agent.CrossFadeQueued(animationToPlay, crossFadeTime);
            } else {
                agent.CrossFade(animationToPlay, crossFadeTime);
            }

            if ( !waitActionFinish ) {
                EndAction(true);
            }
        }

        protected override void OnUpdate() {

            if ( elapsedTime >= ( agent[animationToPlay].length / playbackSpeed ) - crossFadeTime ) {
                EndAction(true);
            }
        }

        Transform FindTransform(Transform parent, string name) {

            if ( parent.name == name )
                return parent;

            var transforms = parent.GetComponentsInChildren<Transform>();

            foreach ( var t in transforms ) {
                if ( t.name == name )
                    return t;
            }

            return null;
        }
    }
}