using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void PlayGame()
    {
        sceneFader.FadeTo(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        sceneFader.FadeTo(0);
    }
}
