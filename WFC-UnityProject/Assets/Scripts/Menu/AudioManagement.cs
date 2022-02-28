using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource audioMaker;

    private void Start()
    {
        audioMaker = GetComponent<AudioSource>();
    }

    public void ChangeSelectionSound ()
    {
        if (audioMaker != null)
        {
            audioMaker.clip = audios[0];
            audioMaker.Play();
        }
    }

    public void SelectSound()
    {
        audioMaker.clip = audios[1];
        audioMaker.Play();
    }

    public void CoinSound ()
    {
        audioMaker.clip = audios[2];
        audioMaker.Play();
    }

    public void SplatSound ()
    {
        StartCoroutine(splat());
    }

    public IEnumerator splat ()
    {
        yield return new WaitForSeconds(.05f);
        audioMaker.clip = audios[3];
        audioMaker.Play();
    }
}
