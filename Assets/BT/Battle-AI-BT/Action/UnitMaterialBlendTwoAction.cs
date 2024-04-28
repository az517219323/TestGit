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
    [Name("���ʻ��")]
    [Category("_����/��Ϊ����")]
    [Description("���ʻ�ϣ������������ߵȴ����ʻ��ִ�����ٽ���")]
    public class UnitMaterialBlendTwoAction : ActionTask
    {
        [Name("�����б�")]
        public BBParameter<List<string>> Materials;
        [Name("���ʱ��")]
        public BBParameter<float> Duration;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        
        public enum ResultTypes
        {
            EndImmediately,
            EndUntilFinish
        }

        [Name("������ʽ")]
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