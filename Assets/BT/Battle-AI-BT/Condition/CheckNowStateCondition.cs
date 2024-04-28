using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("检测当前人物状态")]
[Category("Check")]
public class CheckNowStateCondition : ConditionTask
{
    [BlackboardOnly]
    public BBParameter<int> state;
    public HumanState compareState;

    protected override bool OnCheck()
    {
        return OperationTools.Compare(state.value, (int)compareState, CompareMethod.EqualTo);
    }
}
