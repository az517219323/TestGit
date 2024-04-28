using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("用list长度设置int")]
[Category("Set")]
public class SetIntWithListCountAction<T> : ActionTask
{
    [BlackboardOnly]
    public BBParameter<List<T>> target;
    [BlackboardOnly]
    public BBParameter<int> index;

    protected override void OnExecute()
    {
        index.value = target.value.Count - 1;
        EndAction(true);
    }
}
