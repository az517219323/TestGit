using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite sprite;
    public Image image;
    public Slider slider;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        List<test> list = new List<test>();
        /*list.Add(1);
        list.Add(3);
        list.Add(1);
        list.Add(5);
        list.Add(8);
        list.Add(1);*/
        int a = 3;
        List<test> newList = list.FindAll(x => x.id2 <= a && a <= x.id);
        Debug.LogError(newList.Count);

        Debug.LogError(sprite.textureRect.width + "   " + sprite.textureRect.height);
        time = 0;

        slider.onValueChanged.AddListener(OnValueChanged);

        Debug.Log(SplitString("1,2,3,4,5,6,7,8,9,10").Count);

        Debug.Log(bool.Parse("true") + "        " + bool.Parse("false"));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        /*Color c = Color.Lerp(new Color(0.66f, 0.6f, 0.26f), new Color(1, 0.86f, 0), time);
        image.color = c;*/
    }

    void OnValueChanged(float f)
    {
        image.color = Color.HSVToRGB(1 - f, 1, 1);
    }

    public List<string> SplitString(string str)
    {
        List<string> strList = new List<string>();
        var contentList = str.Split(",\"");
        for (int i = 0; i < contentList.Length; i++)
        {
            if (contentList[i].Contains("\","))
            {
                string[] strArray = contentList[i].Split("\",");
                strList.Add(strArray[0]);
                string[] leftStrArray = strArray[1].Split(",");
                for (int j = 0; j < leftStrArray.Length; j++)
                {
                    strList.Add(leftStrArray[j]);
                }
            }
            else if (contentList[i].Contains("\""))
            {
                strList.Add(contentList[i].Replace("\"", ""));
            }
            else
            {
                string[] strArray = contentList[i].Split(",");
                for (int j = 0; j < strArray.Length; j++)
                {
                    strList.Add(strArray[j]);
                }
            }
        }

        return strList;
    }
}

class test
{
    public int id;
    public int id2;
    public string str;
}
