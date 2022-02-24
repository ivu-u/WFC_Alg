using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("current level before future: " + PlayerPrefs.GetInt("currentLevel"));
        int level = PlayerPrefs.GetInt("currentLevel");
        int future = level + 1;
        Debug.Log("future level:" + future);
        PlayerPrefs.SetInt("currentLevel", future);
        Debug.Log("level after future was set: " + PlayerPrefs.GetInt("currentLevel"));
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
