using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using NodeCanvas.Framework.Internal;

public class Test
{
    public int id;
    public string name;
    public List<string> fieldNameList;
    public int sortId;

    public Test()
    {

    }

    public Test(int _id, string _name,List<string> nameList,int _sortId)
    {
        this.id = _id;
        this.name = _name;
        this.fieldNameList = nameList;
        this.sortId = _sortId;
    }
}

[Category("PFF/Event")]
public class EventAction : ActionTask
{
    [HideInInspector]
    public int eventId;

    [HideInInspector]
    public float arg_0;

    [HideInInspector]
    public float arg_1;

    [HideInInspector]
    public float arg_2;

    [HideInInspector]
    public float arg_3;

    [HideInInspector]
    public float arg_4;
    
    string eventName = "";

    List<BBObjectParameter> parameters = new List<BBObjectParameter>();

    //List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
    List<Test> testList = new List<Test>() {
        new Test(1001, "加速", new List<string>() { "加速度", "距离" },3),
        new Test(2001, "减速", new List<string>() { "加速度", "距离", "人物" },5),
        new Test(3001, "走路", new List<string>() { "移速", "目标位置", "人物","行动时间" },2),
        new Test(4001, "跑步", new List<string>() { "移速" },4),
        new Test(5001, "待机", new List<string>() { "待机时间", "待机位置" },6),
        new Test(6001, "追击", new List<string>() { "目标", "追击速度", "最大距离","追击时间","警戒半径" },1)
    };

    public override void OnCreate(ITaskSystem ownerSystem)
    {
        InitParamters();
    }

    public override void OnValidate(ITaskSystem ownerSystem)
    {
        base.OnValidate(ownerSystem);

        var item = testList.Find(x => x.id == eventId);
        eventName = item != null ? item.name : "";

        InitParamters();
    }

    protected override void OnTaskInspectorGUI()
    {
        eventName = EditorUtils.Popup("事件选择", eventName, testList.Select(x => x.name).ToList());
        if (!string.IsNullOrEmpty(eventName) && eventName != "")
        {
            eventId = testList.Find(x => x.name == eventName).id;
        }
        else
        {
            eventId = 0;
        }

        var fields = this.GetType().RTGetFields().ToList();
        fields = fields.FindAll(p => p.RTGetAttribute(typeof(HideInInspector), false) != null);
        List<string> fieldNameList = GetFieldName(eventId);

        for (int i = 0; i < parameters.Count; i++)
        {
            var field = fields[i + 1];
            string fieldName = fieldNameList.Count == 0 ? field.Name : i < fieldNameList.Count ? fieldNameList[i] : null;

            float num = float.Parse(parameters[i].value.ToString());
            if (string.IsNullOrEmpty(fieldName))
            {
                parameters[i].value = 0;
                field.SetValue(this, parameters[i].value);
            }
            else
            {
                if (IsUseDrop(out List<float> list))
                {
                    field.SetValue(this, EditorUtils.Popup(fieldName, (float)field.GetValue(this), list));
                }
                else
                {
                    NodeCanvas.Editor.BBParameterEditor.ParameterField(fieldName, parameters[i]);
                    field.SetValue(this, num);
                }
            }
        }
        DrawDefaultInspector();
    }

    List<string> GetFieldName(int eventId)
    {
        List<string> fieldNameList = new List<string>();
        if (testList.Find(x => x.id == eventId) != null)
        {
            fieldNameList = testList.Find(x => x.id == eventId).fieldNameList;
        }
        return fieldNameList;
    }

    bool IsUseDrop(out List<float> floatList)
    {
        floatList = null;
        return false;
    }

    void InitParamters()
    {
        parameters.Clear();

        var fields = this.GetType().RTGetFields().ToList();
        fields = fields.FindAll(x => x.RTGetAttribute(typeof(HideInInspector), false) != null);
        List<string> fieldNameList = GetFieldName(eventId);

        for (int i = 1; i < fields.Count; i++)
        {
            var field = fields[i];
            Type T = field.FieldType.IsGenericType ? field.FieldType.GenericTypeArguments[0] : field.FieldType;
            BBObjectParameter newParam = new BBObjectParameter(T) { bb = blackboard };
            newParam.value = field.GetValue(this);
            parameters.Add(newParam);
        }
    }
}
