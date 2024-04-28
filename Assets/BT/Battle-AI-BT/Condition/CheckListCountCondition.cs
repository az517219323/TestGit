using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("��⵱ǰ���鳤����index�Ĵ�С")]
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
