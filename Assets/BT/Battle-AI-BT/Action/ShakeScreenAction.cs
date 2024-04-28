using KLFramework.IOC;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 17:27
    //******************************************
    [Name("震屏")]
    [Category("_昆仑/行为任务")]
    [Description("震屏")]
    public class ShakeScreenAction : ActionTask
    {
        [Name("持续时间")]
        public BBParameter<float> Duration = 0.9f;
        [Name("周期")]
        public BBParameter<float> Period = 0.3f;
        [Name("缩放系数")]
        public BBParameter<float> Scale = 1;
        [Name("上下文")]
        public BBParameter<IBeanContext> BeanContext;

        private CameraController _CameraController;
        private float _RemainTime;
        
        /*
        protected override string info => $"ShakeScreen:Duration=${Duration},Period=${Period},Scale=${Scale}";


        protected override void OnExecute()
        {
            _CameraController = BeanContext.value.FindObjectOfType<CameraController>();
            _CameraController.Shake(Duration.value, Period.value, Scale.value);
            _RemainTime = Duration.value;
        }

        protected override void OnUpdate()
        {
            _RemainTime -= Time.deltaTime;
            
            if (_RemainTime <= 0)
            {
                EndAction(true);
                return;
            }
        }
        */
    }

    internal class CameraController
    {
    }
}