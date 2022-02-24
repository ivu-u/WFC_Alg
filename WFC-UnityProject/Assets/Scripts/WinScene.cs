using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("currentLevel");
        int future = level + 1;
        PlayerPrefs.SetInt("currentLevel", future);
        if(PlayerPrefs.GetInt("highestReached") < future)
        {
            PlayerPrefs.SetInt("highestReached", future);
        }
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
