using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("随机获取与当前索引对应的元素不同的元素")]
[Category("Check")]
public class PickRandomListDIfferentAction<T> : ActionTask
{
    public BBParameter<List<T>> targetList;
    public BBParameter<int> currentIndex;

    [BlackboardOnly]
    public BBParameter<T> saveAs;

    protected override string info
    {
        get { return string.Format("{0}={1}.Random except {2}", saveAs, targetList, currentIndex); }
    }
    protected override void OnExecute()
    {
        if (targetList.value == null || targetList.value.Count <= 0)
        {
            EndAction(false);
            return;
        }

        int index = currentIndex.value;
        while (index == currentIndex.value)
        {
            index = Random.Range(0, targetList.value.Count);
        }

        saveAs.value = targetList.value[index];
        currentIndex.value = index;
        EndAction(true);
    }
}
