using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => {
            SceneManager.LoadScene("Test", LoadSceneMode.Additive);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
