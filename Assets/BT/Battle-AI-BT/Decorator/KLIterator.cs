using System.Collections;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion;
using UnityEngine;
using NodeCanvas.BehaviourTrees;

namespace KLGame.OP.Battle.BTAI
{

    [Name("迭代器")]
    [Category("_昆仑/装饰")]
    [Description("迭代列表，为每个元素执行子节点，知道满足迭代结束条件或者迭代完整个列表,返回最后一个元素的子节点状态")]
    [ParadoxNotion.Design.Icon("List")]
    public class KLIterator : BTDecorator
    {
        //public enum TerminationConditions
        //{
        //    None,
        //    FirstSuccess,
        //    FirstFailure
        //}

        [RequiredField]
        [BlackboardOnly]
        [Tooltip("The list to iterate")]
        [Name("迭代列表")]
        public BBParameter<IList> targetList;

        [BlackboardOnly]
     
        [Tooltip("Store the current element")]
        [Name("当前节点")]
        public BBObjectParameter current;

        //[BlackboardOnly]
        //[Name("迭代索引")]
        //[Tooltip("Store the current index")]
        //public BBParameter<int> storeIndex;

        //[Tooltip("The condition when to terminate the iteration and return status")]
        //[Name("结束条件")]
        //public TerminationConditions terminationCondition = TerminationConditions.None;

        //[Tooltip("Should the iteration start from the begining after a node reset?")]
        //[Name("是否重置索引")]
        //public bool resetIndex = true;
        
        //private int currentIndex;

        private IList list => targetList != null ? targetList.value : null;

        //private Status[] _Statuses;

        protected override Status OnExecute(Component agent, IBlackboard blackboard) {

            if ( decoratedConnection == null ) {
                return Status.Optional;
            }

            if ( list == null || list.Count == 0 ) {
                return Status.Failure;
            }

            for ( var i = 0; i < list.Count; i++ )
            {
                //currentIndex = i;
                current.value = list[i];
                //Debug.LogError("Set " + i + " value=" + current.value);
                //storeIndex.value = i;
                status = decoratedConnection.Execute(agent, blackboard);

                // if ( status == Status.Success && terminationCondition == TerminationConditions.FirstSuccess ) {
                //     return Status.Success;
                // }
                //
                // if ( status == Status.Failure && terminationCondition == TerminationConditions.FirstFailure ) {
                //     return Status.Failure;
                // }
                //
                // if ( status == Status.Running ) {
                //     currentIndex = i;
                //     return Status.Running;
                // }
                //
                //
                // if ( currentIndex == list.Count - 1 || currentIndex == maxIteration.value - 1 ) {
                //     if ( resetIndex ) { currentIndex = 0; }
                //     return status;
                // }

                decoratedConnection.Reset();
                //currentIndex++;
            }

            return Status.Success;
        }


        protected override void OnReset() {
            //if ( resetIndex ) { currentIndex = 0; }
        }
       
        
        ///----------------------------------------------------------------------------------------------
        ///---------------------------------------UNITY EDITOR-------------------------------------------
#if UNITY_EDITOR

        protected override void OnNodeGUI() {

            GUILayout.Label("For Each\t" + current + "\nIn\t" + targetList, Styles.leftLabel);
            //if ( terminationCondition != TerminationConditions.None ) {
            //    GUILayout.Label("Break on " + terminationCondition.ToString());
            //}

            //if ( Application.isPlaying ) {
            //    GUILayout.Label("Index: " + currentIndex.ToString() + " / " + ( list != null && list.Count != 0 ? ( list.Count - 1 ).ToString() : "?" ));
            //}
        }

        protected override void OnNodeInspectorGUI() {
            DrawDefaultInspector();
            var argType = targetList.refType != null ? targetList.refType.GetEnumerableElementType() : null;
            if ( current.varType != argType ) { current.SetType(argType); }
        }
#endif
        
    }
}