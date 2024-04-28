using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System.Reflection;
using System;

public class BTExport : Editor
{

    [MenuItem("策划工具/导出行为树数据")]
    public static void Export() 
    {
        object obj = Selection.activeObject;
        if (obj != null) 
        {
            ExportBehaviourTree(obj);
        }
    }

    [MenuItem("Assets/导出行为树数据")]
    public static void Export2()
    {
        object obj = Selection.activeObject;
        if (obj != null)
        {
            ExportBehaviourTree(obj);
        }
    }

    [MenuItem("Assets/上传行为树")]
    public static void ToSVN()
    {
        object obj = Selection.activeObject;
        if (obj != null)
        {
            SVNBehaviourTree(obj);
        }
    }

    public static void SVNBehaviourTree(object obj)
    {
        /*string[] paths = {
            Application.dataPath + "/EditTools/Data/AIAsset",
            EditorUtil.EXPORT_PATH_COMMON + "AIData",
        };
        EditorUtil.CommitSVN(paths);*/
    }

    public static void ExportBehaviourTree(object obj) 
    {
        BehaviourTree bt = obj as BehaviourTree;
        if (bt != null)
        {
            BehaviouTreeData btData = new BehaviouTreeData();
            Debug.Log("导出行为树：" + bt.name);
            btData.name = bt.name;
            btData.repeatFlag = bt.repeat;
            btData.updateInterval = bt.updateInterval;

            BTBlackBoardData blackboardData = new BTBlackBoardData();
            btData.blackBoard = blackboardData;
            List<BTBBParamData> paramList = new List<BTBBParamData>();
            paramList.AddRange(GetParamFromBlackBorad(bt.blackboard));
            paramList.AddRange(GetParamFromBlackBorad(bt.blackboard.parent));
            btData.blackBoard.param = paramList.ToArray();

            List<BTNodeData> nodeList = new List<BTNodeData>();
            for (int i = 0; i < bt.allNodes.Count; i++)
            {
                Node node = bt.allNodes[i];
                nodeList.Add(GetNode(node));
            }
            btData.nodes = nodeList.ToArray();


            string path = AssetDatabase.GetAssetPath(bt);
            Debug.Log("原路径:" + path);
            int pos = path.LastIndexOf("/");
            string forderName = "";
            if (pos > 0) 
            {
                path = path.Substring(0, pos);
                pos = path.LastIndexOf("/");
                if (pos > 0) 
                {
                    forderName = path.Substring(pos + 1);
                }
            }

            string rootPath = Application.dataPath + "/../Lua/Data/common/AIData/";
            //if (!string.IsNullOrEmpty(forderName)) 
            //{
            //    rootPath += forderName + "/";
            //}

            string fileName = bt.name + ".lua";
            //LuaCodeUtil.ToLuaFile(btData, "BehaviourTree", rootPath, fileName);
        }
    }


    public static List<BTBBParamData> GetParamFromBlackBorad( IBlackboard blackboard) 
    {
        List<BTBBParamData> list = new List<BTBBParamData>();

        if (blackboard == null) 
        {
            return list;
        }

        Debug.Log("黑板: " + blackboard.identifier);
        foreach (string key in blackboard.variables.Keys)
        {
            Variable v = blackboard.variables[key];
            BTBBParamData btPamraData = new BTBBParamData();
            btPamraData.name = v.name;
            btPamraData.guid = v.ID;
            btPamraData.value = v.value;
            btPamraData.valueType = v.varType;
            list.Add(btPamraData);
            Debug.Log("变量：" + v.name + " : " + v.ID + " : "  + v.varType);
        }

        return list;
    }


    public static BTNodeData GetNode(Node node) 
    {
        BTNodeData nodeData = new BTNodeData();
        nodeData.typeName = node.GetType().ToString();
        nodeData.id = node.ID;
        Debug.Log("=========节点：" + node.ID);

        nodeData.param = GetParam(node);

        List<int> outCons = new List<int>();
        if (node.outConnections.Count > 0)
        {
            for (int i = 0; i < node.outConnections.Count; i++)
            {
                Connection c = node.outConnections[i];
                outCons.Add(c.targetNode.ID);
                Debug.Log("子节点: " + c.targetNode.ID);
            }
        }
        nodeData.outConnections = outCons.ToArray();
        nodeData.taskDatas = GetTaskData(node);

        return nodeData;
    }

    public static BTTaskData[] GetTaskData(Node node) 
    {
        List<BTTaskData> list = new List<BTTaskData>();

        foreach (Task task in Graph.GetTasksInElement(node))
        {
            BTTaskData taskData = new BTTaskData();
            taskData.typeName = task.GetType().ToString();
            if (taskData.typeName.Contains("KLGame.OP.Battle.BTAI.UnitBlackboardAction"))
            {
                taskData.typeName = "KLGame.OP.Battle.BTAI.UnitBlackboardAction";
            }
            else if (taskData.typeName.Contains("NodeCanvas.Tasks.Actions.PickListElement"))
            {
                taskData.typeName = "NodeCanvas.Tasks.Actions.PickListElement";
            }
            Debug.Log("任务名字：" + taskData.typeName);
            taskData.isUserEnabled = task.isUserEnabled;
            taskData.param = GetParam(task);

            list.Add(taskData);
        }

        return list.ToArray();
    }


    public static BTParamData[] GetParam(object obj) 
    {
        List<BTParamData> list = new List<BTParamData>();

        FieldInfo[] fieldInfos = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        for (int k = 0; k < fieldInfos.Length; k++)
        {
            FieldInfo fieldInfo = fieldInfos[k];
            var value = fieldInfo.GetValue(obj);

            BTParamData paramData = new BTParamData();

            if (fieldInfo.FieldType.ToString().Contains("BBParameter") || fieldInfo.FieldType.ToString().Contains("BBObjectParameter"))
            {
                BBParameter param = value as BBParameter;
                paramData.isBBParam = true;

                if (!string.IsNullOrEmpty(param.targetVariableID))
                {
                    paramData.name = fieldInfo.Name;
                    paramData.guid = param.targetVariableID;
                    Debug.Log("BB参数：" + paramData.name + "   GUID：" + paramData.guid);
                }
                else 
                {
                    paramData.guid = null;
                    paramData.name = fieldInfo.Name;
                    paramData.value = param.value;
                    paramData.valueType = GetGenericParamType(fieldInfo);
                    Debug.Log("BB普通参数: " + paramData.name + "   值:" + paramData.value + "  类型：" + paramData.valueType);
                }
            }
            else
            {
                paramData.name = fieldInfo.Name;
                paramData.value = fieldInfo.GetValue(obj);
                paramData.valueType = fieldInfo.FieldType;
                paramData.isBBParam = false;
                Debug.Log("普通参数: " + paramData.name + "   值:" + paramData.value + "  类型：" + paramData.valueType);
            }

            //注意，只处理变量名不为空的参数
            if (!string.IsNullOrEmpty(paramData.name)) 
            {
                list.Add(paramData);
            }
        }

        return list.ToArray();
    }


    public static Type GetGenericParamType(FieldInfo fieldInfo) 
    {
        Type[] paramTypes = fieldInfo.FieldType.GenericTypeArguments;
        if (paramTypes.Length > 0) 
        {
            return paramTypes[0];
        }
        return fieldInfo.FieldType;
    }
}
