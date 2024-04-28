using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("�ı�����״̬")]
[Category("Check")]
public class ChangeStateAction : ActionTask
{
    [BlackboardOnly]
    public BBParameter<int> state;
    public HumanState targetState;

    protected override void OnExecute()
    {
        state = (int)targetState;
        EndAction();
    }
}
