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
    [Name("����")]
    [Category("_����/��Ϊ����")]
    [Description("����")]
    public class ShakeScreenAction : ActionTask
    {
        [Name("����ʱ��")]
        public BBParameter<float> Duration = 0.9f;
        [Name("����")]
        public BBParameter<float> Period = 0.3f;
        [Name("����ϵ��")]
        public BBParameter<float> Scale = 1;
        [Name("������")]
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