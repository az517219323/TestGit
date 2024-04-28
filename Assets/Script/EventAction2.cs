using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EventAction2 : ActionTask
{
    [HideInInspector]
    public int eventId;

    [HideInInspector]
    public BBParameter<float> arg_0;

    [HideInInspector]
    public BBParameter<float> arg_1;

    [HideInInspector]
    public BBParameter<float> arg_2;

    [HideInInspector]
    public BBParameter<float> arg_3;

    [HideInInspector]
    public BBParameter<float> arg_4;

    string eventName = "";

    List<Test> testList = new List<Test>() {
        new Test(1001, "����", new List<string>() { "���ٶ�", "����" },3),
        new Test(2001, "����", new List<string>() { "���ٶ�", "����", "����" },5),
        new Test(3001, "��·", new List<string>() { "����", "Ŀ��λ��", "����","�ж�ʱ��" },2),
        new Test(4001, "�ܲ�", new List<string>() { "����" },4),
        new Test(5001, "����", new List<string>() { "����ʱ��", "����λ��" },6),
        new Test(6001, "׷��", new List<string>() { "Ŀ��", "׷���ٶ�", "������","׷��ʱ��","����뾶" },1)
    };

    public override void OnValidate(ITaskSystem ownerSystem)
    {
        base.OnValidate(ownerSystem);

        var item = testList.Find(x => x.id == eventId);

        eventName = item != null ? item.name : "";
    }

    protected override void OnTaskInspectorGUI()
    {
        base.OnTaskInspectorGUI();

        List<string> eventNameList = testList.Select(x => x.name).ToList();

        eventName = EditorUtils.Popup("�¼�ѡ��", eventName, eventNameList);

        var fields = this.GetType().RTGetFields().ToList().FindAll(x => x.RTGetAttribute(typeof(HideInInspector), false) != null);

        List<string> fieldsNameList = testList.Find(x => x.id == eventId).fieldNameList;
        for (int i = 1; i < fields.Count; i++)
        {
            var fieldName = i < fieldsNameList.Count + 1 ? fieldsNameList[i - 1] : fields[i].Name;
            DrawFields(i, fieldName);
        }

    }

    void DrawFields(int index,string name)
    {
        switch (index)
        {
            case 1: NodeCanvas.Editor.BBParameterEditor.ParameterField(name, arg_0); break;
            case 2: NodeCanvas.Editor.BBParameterEditor.ParameterField(name, arg_1); break;
            case 3: NodeCanvas.Editor.BBParameterEditor.ParameterField(name, arg_2); break;
            case 4: NodeCanvas.Editor.BBParameterEditor.ParameterField(name, arg_3); break;
            case 5: NodeCanvas.Editor.BBParameterEditor.ParameterField(name, arg_4); break;
        }
    }
}
