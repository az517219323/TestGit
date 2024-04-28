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
    [Name("���úڰ����")]
    [Category("_����/��Ϊ����")]
    [Description("���úڰ����")]
    public class UnitBlackboardAction<T> : ActionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> Unit;
        [Name("��������")]
        public BBParameter<string> Key;
        [Name("����ֵ")]
        public BBParameter<T> Value;
        [Name("��������")]
        public BBParameter<OPType> Operation;

        public enum OPType
        {
            Set,
            Get
        }
            
        
        /*
        protected override void OnExecute()
        {
            if (Operation.value == OPType.Get)
            {
                var blackboardComponent = Unit.value.GetComponent<BlackboardComponent>();
                T t = blackboardComponent.GetValue<T>(Key.value);
                Value.SetValue(t);
            }
            else
            {
                var blackboardComponent = Unit.value.GetComponent<BlackboardComponent>();
                blackboardComponent.SetValue(Key.value, Value.value);
            }
            
            EndAction(true);
        }
        */
    }
}