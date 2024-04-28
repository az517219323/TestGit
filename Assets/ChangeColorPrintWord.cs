using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Test1
{
    public int A;
    public int B;

    public Test1()
    {

    }

    public Test1(int a,int b)
    {
        A = a;
        B = b;
    }

    public Test1(Test1 a)
    {
        A = a.A;
        B = a.B;
    }
}


public class ChangeColorPrintWord : MonoBehaviour
{
    public TMP_Text text;
    public Text oldText;

    List<Test1> testList = new List<Test1>() { new Test1(1, 2), new Test1(3, 4) };

    string str = "Google翻譯是一項由Google於2006年開始提供的翻譯文段及網頁的服務。與其他網站巴別魚、美國線上及雅虎使用的SYSTRAN引擎不同的是，Google使用自己開發的翻譯軟體。至2015年6月，Google翻譯稱每天需要處理超過1000億筆字詞";
        /*"The city has carried out multiple rounds of regional nucleic acid screening, which has played an important role in identifying risks, managing them, and blocking the spread of the epidemic. At present, the city's epidemic prevention and control is still at a critical stage. In order to quickly block the spread of the virus, curb the spread of the epidemic, and effectively protect the health and safety of the people in the area, in accordance with the requirements of the district party committee and district government's epidemic prevention and control work, Jianguomen Street will Three rounds of regional nucleic acid screening continued on May 3, 4 and 5. In order to speed up the test and reduce the queuing time, local residents are requested to follow the specific requirements of their communities, bring their ID cards and mobile phones (check the health treasure), and go to the following test points to complete nucleic acid screening as soon as possible. When testing, please keep a distance of two meters, wear a mask, and do personal protection. The end time is subject to the notification time of each community on that day.";*/
    float time = 0;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeColor");
        ChangeColor();
        var a1 = testList[0];
        var b1 = new Test1(testList[0]);
        a1.A = 88;
        Debug.Log(b1.A);
        var list = TableManager.Instance.settingInfoTable.GetDataAll().Select(x => x.CharacterId).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ChangeColor()
    {
        while (index < str.Length)
        {
            Color color = Color.HSVToRGB(time, 1, 1);
            string colorStr = ColorUtility.ToHtmlStringRGB(color);
            oldText.text += "<color=#" + colorStr + ">" + str[index] + "</color>";
            index++;
            time += 1.0f / str.Length;
            if (time >= 1)
            {
                time = 0;
            }
            yield return null;
        }
    }
}
