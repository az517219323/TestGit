using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BehaviouTreeData
{
    public string name;
    public bool repeatFlag = true;
    public float updateInterval = 0;
    public BTBlackBoardData blackBoard;
    public BTNodeData[] nodes;
}


