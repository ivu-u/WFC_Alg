using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    bool optionsOpened = false;
    public GameObject optionsPanel;
    public SceneFader sf;
    public GameObject resume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && optionsOpened == false)
        {
            OpenOptions();
        }
    }

    public void OpenOptions ()
    {
        optionsOpened = true;
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void CloseOptions ()
    {
        optionsOpened = false;
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GetMenu ()
    {
        Time.timeScale = 1;
        sf.FadeTo(0);
    }

    public void ReloadLevel ()
    {
        Time.timeScale = 1;
        sf.FadeTo(4);
    }
}
