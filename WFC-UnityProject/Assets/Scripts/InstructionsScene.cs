using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScene : MonoBehaviour
{
    public float waitTime;
    public SceneFader sf;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstructionsTime());
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            sf.FadeTo(1);
        }
    }

    public IEnumerator InstructionsTime()
    {
        yield return new WaitForSeconds(waitTime);
        sf.FadeTo(1);
    }
}
