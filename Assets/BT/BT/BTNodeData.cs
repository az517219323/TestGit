using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class BTNodeData
{
    public string typeName;
    public int id;
    public BTParamData[] param = new BTParamData[0];
    public int[] outConnections;
    public BTTaskData[] taskDatas;
}
