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
    // @Date: 2021-09-02 20:25
    //******************************************
    [Name("获取时间")]
    [Category("_昆仑/行为任务")]
    [Description("获取当前时间和当前帧更新时间")]
    public class GetTimeAction : ActionTask
    {
        [Name("当前时间")]
        public BBParameter<float> TimeValue;
        [Name("每帧更新时间")]
        public BBParameter<float> DeltaTimeValue;
        
        /*
        protected override void OnExecute()
        {
            if (TimeValue != null)
            {
                TimeValue.value = Time.time;    
            }

            if (DeltaTimeValue != null)
            {
                DeltaTimeValue.value = Time.deltaTime;    
            }
            EndAction(true);
        }
        */
    }
}