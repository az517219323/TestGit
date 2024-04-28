using System;
using System.Collections.Generic;
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
    // @Date: 2021-07-28 11:31
    //******************************************
    [Name("材质混合")]
    [Category("_昆仑/行为任务")]
    [Description("材质混合，立即结束或者等待材质混合执行完再结束")]
    public class UnitMaterialBlendTwoAction : ActionTask
    {
        [Name("材质列表")]
        public BBParameter<List<string>> Materials;
        [Name("混合时间")]
        public BBParameter<float> Duration;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        
        public enum ResultTypes
        {
            EndImmediately,
            EndUntilFinish
        }

        [Name("结束方式")]
        public BBParameter<ResultTypes> ResultType = ResultTypes.EndImmediately;

        /*
        protected override string info => "Blend Two " + Duration;

        protected override void OnExecute()
        {
            BattleUnit battleUnit = BattleUnit.value;//blackboard.GetVariable<BattleUnit>("BattleUnit").value;
            var materialComponent = battleUnit.MatCom;
            Action onEnd = null;
            if (ResultType.value == ResultTypes.EndUntilFinish)
            {
                onEnd = () =>
                {
                    EndAction(true);
                };
            }
            
            materialComponent.StartBlendTwo(Materials.value, Duration.value, -1, 1, onEnd);

            if (ResultType.value == ResultTypes.EndImmediately)
            {
                EndAction(true);    
            }
        }
        */
    }
}