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
    [Name("�ɹ�����", 9)]
    [Category("_����/���")]
    [ParadoxNotion.Design.Icon("Sequencer")]
    [Description("˳��ִ�У���ǰ�ӽڵ�ɹ��󣬲���ִ����һ���ڵ㣬�����ӽڵ�ɹ������سɹ�")]
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