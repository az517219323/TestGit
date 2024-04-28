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
    [Name("随机数")]
    [Category("_昆仑/条件任务")]
    [Description("在（0,100）之间随机一个值，判断是否小于目标值")]
    public class ProbabilityCondition : ConditionTask
    {
        [Name("小于目标值")]
        public BBParameter<float> Probability;
        
        protected override string info {
            get { return Probability + "%"; }
        }
        
        protected override bool OnCheck() {
            return Random.Range(0f, 100f) < Probability.value;
        }
    }
}