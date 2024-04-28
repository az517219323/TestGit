using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Name("ºÏ≤‚æ‡¿Î")]
[Category("Check")]
public class CheckDistanceCondition : ConditionTask<Transform>
{
    [BlackboardOnly]
    public BBParameter<Transform> target;
    public BBParameter<float> mixDistance;
    protected override bool OnCheck()
    {
        return Vector3.Distance(agent.position, target.value.position) > mixDistance.value;
    }
}
