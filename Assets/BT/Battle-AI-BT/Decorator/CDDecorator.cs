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
    [Name("CD�ڵ�")]
    [Category("_����/װ��")]
    [Description("���ӽڵ�ִ�гɹ������õ�ǰCDֵΪĿ��CD")]
    public class CDDecorator : BTDecorator
    {
        [Name("��ʼCD")]
        public BBParameter<float> CurrentCD;
        [Name("ѭ��CD")]
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