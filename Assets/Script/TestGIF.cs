using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGIF : MonoBehaviour
{
    public Button clickBtn;
    bool isRecording = false;
    // Start is called before the first frame update
    void Start()
    {
        clickBtn.onClick.AddListener(() =>
        {
            Debug.LogError("开始导出");
            MediaEncoderTest.RecordMovie();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
