using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[LuaCallCSharp]
public class BTDebug : MonoBehaviour
{
    public BehaviourTree btTree;
    private Node[] nodes;
    public float elapsedTime;
    public string btTreeName;
    public BTNodeDebug[] debugNodes;


    private static BTDebug instance = null;
    /*
    public static void SetDebugData(LuaTable luaTable) 
    {
        if (instance == null) 
        {
            GameObject go = new GameObject();
            go.name = "BTDebug";
            instance = go.AddComponent<BTDebug>();
        }

        if (instance != null) 
        {
            instance.SetData(luaTable);
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void SetData(LuaTable luaTable) 
    {
        if (!IsValid())
        {
            return;
        }

        btTreeName = luaTable.Get<string>("name");
        if (btTreeName != btTree.name) 
        {
            return;
        }
        

        elapsedTime = luaTable.Get<float>("elapsedTime")/1000;
       // Debug.Log("elapsedTime " + elapsedTime);
        List<LuaTable> list = luaTable.Get<List<LuaTable>>("nodes");
        for (int i = 0; i < list.Count; i++) 
        {
            LuaTable data = list[i];

            int id = data.Get<int>("id");
            int status = data.Get<int>("status");
            float timeStarted = data.Get<float>("timeStarted")/1000;

            //Debug.Log("节点 " + id+" "+ status+" "+ timeStarted);
            if (debugNodes != null) 
            {
                if (id < debugNodes.Length)
                {
                    BTNodeDebug nodeDebug = debugNodes[id];
                    nodeDebug.timeStarted = timeStarted;
                    nodeDebug.status = status;
                }
            }
        } 
    }

    private bool IsValid() 
    {
        if (btTree == null)
        {
            return false;
        }

        if (nodes == null)
        {
            return false;
        }

        if (debugNodes == null)
        {
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
#if UNITY_EDITOR
        if (NodeCanvas.Editor.GraphEditor.current == null) 
        {
            btTree = null;
            nodes = null;
            debugNodes = null;
            return;
        }

        if (NodeCanvas.Editor.GraphEditor.currentGraph == null) 
        {
            return;
        }


        if (btTree == null) 
        {
            btTree = NodeCanvas.Editor.GraphEditor.currentGraph as BehaviourTree;
            if (btTree != null)
            {
                nodes = btTree.allNodes.ToArray();
                debugNodes = new BTNodeDebug[nodes.Length];
                for (int i = 0;i<nodes.Length; i++) 
                {
                    BTNodeDebug debugNode = new BTNodeDebug();
                    Node node = nodes[i];
                    debugNode.id = node.ID;
                    debugNode.timeStarted = node.timeStarted;
                    debugNode.status = (int)node.status;
                    debugNodes[i] = debugNode;
                }
              
            }
        }
#endif

        if (!IsValid()) 
        {
            return;
        }

        if (string.IsNullOrEmpty(btTreeName)) 
        {
            return;
        }

        if (btTreeName != btTree.name) 
        {
            return;
        }

        btTree.elapsedTime = elapsedTime;
        for (int i = 0; i < nodes.Length; i++)
        {
            BTNodeDebug debugNode = debugNodes[i];
            Node node = nodes[i];

            node.timeStarted = debugNode.timeStarted;
            node.status = (Status)debugNode.status;

            foreach (Connection con in node.inConnections) 
            {
                con.status = node.status;
            }
        }
    }*/
}
