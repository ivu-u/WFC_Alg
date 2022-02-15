using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int index)
    {
        StartCoroutine(FadeOut(index));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;    // time

        while (t>0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;         // wait a frame and then continue
        }
    }

    IEnumerator FadeOut(int index)
    {
        float t = 0f;    // time

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;         // wait a frame and then continue
        }
        SceneManager.LoadScene(index);
    }
}
