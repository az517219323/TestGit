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
    [Name("执行全部", 9)]
    [Category("_昆仑/组合")]
    [ParadoxNotion.Design.Icon("Sequencer")]
    [Description("顺序执行，不管子节点成功失败都会执行全部节点，返回最后一个子节点的结果，")]
    public class OrderSelector : BTComposite
    {
        private int lastRunningNodeIndex;

        protected override Status OnExecute(Component agent, IBlackboard blackboard)
        {
            for (int i = lastRunningNodeIndex; i < outConnections.Count; i++){
                status = outConnections[i].Execute(agent, blackboard);

                if (status == Status.Running)
                {
                    break;
                }

                lastRunningNodeIndex = i;
            }
            return status;
        }
        
        protected override void OnReset(){
           // Debug.LogError("OnReset");
            lastRunningNodeIndex = 0;
        }
    }
}