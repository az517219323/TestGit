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
    [Name("CD节点")]
    [Category("_昆仑/装饰")]
    [Description("当子节点执行成功后，设置当前CD值为目标CD")]
    public class CDDecorator : BTDecorator
    {
        [Name("初始CD")]
        public BBParameter<float> CurrentCD;
        [Name("循环CD")]
        public BBParameter<float> CD;
        /*
        protected override Status OnExecute(Component agent, IBlackboard blackboard) {

            if ( decoratedConnection == null ) {
                return Status.Optional;
            }

            if (CurrentCD.value <= 0)
            {
                status = decoratedConnection.Execute(agent, blackboard);
                if ( status == Status.Success )
                {
                    CurrentCD.value = CD.value;
                }
            }

            return status;
        }
        */
    }
}