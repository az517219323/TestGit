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
        [Name("动画")]
        public BBParameter<AnimationClip> animationClip;
        [Name("播放模式")]
        public WrapMode animationWrap;
        [Name("混合模式")]
        public AnimationBlendMode blendMode;
        [SliderField(0, 2)]
        [Name("播放速度")]
        public float playbackSpeed = 1;
        [SliderField(0, 1)]
        [Name("淡入淡出时间")]
        public float crossFadeTime = 0.25f;
        [Name("播放方向")]
        public PlayDirections playDirection = PlayDirections.Forward;
        [Name("动画混合部位")]
        public BBParameter<string> mixTransformName;
        [Name("动画层级")]
        public BBParameter<int> animationLayer;
        [Name("是否为队列动画")]
        public bool queueAnimation;
        [Name("是否等待Action结束")]
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