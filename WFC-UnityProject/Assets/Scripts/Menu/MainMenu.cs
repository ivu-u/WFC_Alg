using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI tm;

    private void Start()
    {
        PlayerPrefs.SetInt("currentLevel", 0);
        tm.text = "High score: " + PlayerPrefs.GetInt("highestReached");
    }
    public SceneFader sceneFader;

    public void PlayGame()
    {
        sceneFader.FadeTo(5);
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
