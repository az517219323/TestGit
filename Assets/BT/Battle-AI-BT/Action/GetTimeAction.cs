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
    [Name("��ȡʱ��")]
    [Category("_����/��Ϊ����")]
    [Description("��ȡ��ǰʱ��͵�ǰ֡����ʱ��")]
    public class GetTimeAction : ActionTask
    {
        [Name("��ǰʱ��")]
        public BBParameter<float> TimeValue;
        [Name("ÿ֡����ʱ��")]
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