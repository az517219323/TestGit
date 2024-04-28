using System.Collections.Generic;
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
    // @Date: 2021-07-30 11:06
    //******************************************
    [Name("�����")]
    [Category("_����/��������")]
    [Description("�ڣ�0,100��֮�����һ��ֵ���ж��Ƿ�С��Ŀ��ֵ")]
    public class ProbabilityCondition : ConditionTask
    {
        [Name("С��Ŀ��ֵ")]
        public BBParameter<float> Probability;
        
        protected override string info {
            get { return Probability + "%"; }
        }
        
        protected override bool OnCheck() {
            return Random.Range(0f, 100f) < Probability.value;
        }
    }
}