using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("检测当前数组长度与index的大小")]
[Category("Check")]
public class CheckListCountCondition<T> : ConditionTask
{
    [BlackboardOnly]
    public BBParameter<List<T>> targetList;
    public CompareMethod compare;
    public BBParameter<int> index;

    protected override bool OnCheck()
    {
        return OperationTools.Compare(targetList.value.Count, index.value, compare);
    }
}
