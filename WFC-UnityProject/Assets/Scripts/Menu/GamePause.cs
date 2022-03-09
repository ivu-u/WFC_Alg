using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamePause : MonoBehaviour
{
    bool optionsOpened = false;
    public GameObject optionsPanel;
    public SceneFader sf;
    public GameObject resume;
    EventSystem es;

    // Start is called before the first frame update
    void Start()
    {
        es = this.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Alpha2)) && optionsOpened == false)
        {
            OpenOptions();
        }
    }

    public void OpenOptions ()
    {
        optionsOpened = true;
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        StartCoroutine(SelectContinueButtonLater());
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

    IEnumerator SelectContinueButtonLater()
    {
        yield return null;
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(resume.gameObject);
    }
}
