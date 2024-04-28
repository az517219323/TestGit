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
    // @Date: 2021-07-21 15:09
    //******************************************
    [Name("成功继续", 9)]
    [Category("_昆仑/组合")]
    [ParadoxNotion.Design.Icon("Sequencer")]
    [Description("顺序执行，当前子节点成功后，才能执行下一个节点，所有子节点成功，返回成功")]
    public class ActionSequencer : BTComposite
    {
        private int lastRunningNodeIndex;

        protected override Status OnExecute(Component agent, IBlackboard blackboard)
        {
            for (int i = lastRunningNodeIndex; i < outConnections.Count; i++){
                status = outConnections[i].Execute(agent, blackboard);

                if (status != Status.Success)
                {
                    break;
                }

                lastRunningNodeIndex = i;
            }
            return status;
        }
        
        protected override void OnReset(){
            //Debug.LogError("OnReset");
            lastRunningNodeIndex = 0;
        }
    }
}