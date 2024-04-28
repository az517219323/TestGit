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
    [Name("设置黑板变量")]
    [Category("_昆仑/行为任务")]
    [Description("设置黑板变量")]
    public class UnitBlackboardAction<T> : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> Unit;
        [Name("变量名称")]
        public BBParameter<string> Key;
        [Name("变量值")]
        public BBParameter<T> Value;
        [Name("操作类型")]
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