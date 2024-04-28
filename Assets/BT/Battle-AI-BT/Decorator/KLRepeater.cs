using NodeCanvas.BehaviourTrees;
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
    // @Date: 2021-07-22 11:33
    //******************************************
    //[Name("KL Repeater")]
    //[Category("KL/Decorator")]
    //[Description("KLCustom - Repeater Decorator")]

    [Name("重复执行")]
    [Category("_昆仑/装饰")]
    [Description("")]
    [ParadoxNotion.Design.Icon("List")]

    public class KLRepeater : BTDecorator
    {
        
        public enum RepeaterMode
        {
            RepeatTimes = 0,
            RepeatUntil = 1,
            RepeatForever = 2
        }

        public enum RepeatUntilStatus
        {
            Failure = 0,
            Success = 1
        }

        [Name("重复模式")]
        public RepeaterMode repeaterMode = RepeaterMode.RepeatTimes;
        [ShowIf("repeaterMode", 0)]
        [Name("重复次数")]
        public BBParameter<int> repeatTimes = 1;
        [ShowIf("repeaterMode", 1)]
        [Name("结束条件")]
        public RepeatUntilStatus repeatUntilStatus = RepeatUntilStatus.Success;

        private int currentIteration = 1;

        protected override Status OnExecute(Component agent, IBlackboard blackboard) {

            if ( decoratedConnection == null ) {
                return Status.Optional;
            }
            
            while (currentIteration < repeatTimes.value)
            {
                if ( decoratedConnection.status == Status.Success || decoratedConnection.status == Status.Failure ) {
                    decoratedConnection.Reset();
                }

                status = decoratedConnection.Execute(agent, blackboard);

                switch ( status ) {
                    case Status.Resting:
                        return Status.Running;
                    case Status.Running:
                        return Status.Running;
                }

                switch ( repeaterMode ) {
                    case RepeaterMode.RepeatTimes:

                        if ( currentIteration >= repeatTimes.value ) {
                            return status;
                        }

                        currentIteration++;
                        break;

                    case RepeaterMode.RepeatUntil:

                        if ( (int)status == (int)repeatUntilStatus ) {
                            return status;
                        }
                        break;
                }
            }
            
            return Status.Success;
        }

        protected override void OnReset() {
            currentIteration = 1;
        }


        ///----------------------------------------------------------------------------------------------
        ///---------------------------------------UNITY EDITOR-------------------------------------------
#if UNITY_EDITOR

        protected override void OnNodeGUI() {

            if ( repeaterMode == RepeaterMode.RepeatTimes ) {
                GUILayout.Label(repeatTimes + " Times");
                if ( Application.isPlaying )
                    GUILayout.Label("Iteration: " + currentIteration.ToString());

            } else if ( repeaterMode == RepeaterMode.RepeatUntil ) {

                GUILayout.Label("Until " + repeatUntilStatus);

            } else {

                GUILayout.Label("Repeat Forever");
            }
        }

#endif
    }
}