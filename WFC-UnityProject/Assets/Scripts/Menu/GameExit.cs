using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Unlock ()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float timeElapsed = 0;
            while(timeElapsed < 1f)
            {
                //move position
                Vector3.Lerp(player.transform.position, this.transform.position, timeElapsed/1f);
                timeElapsed += Time.deltaTime;
            }
            
            StartCoroutine(Exit());
        }
    }

    public IEnumerator Exit()
    {
        //freeze movement
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().runSpeed = 0;

        //freeze enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<SimpleEnemy3>().moveSpeed = 0;
        }

        //play sounds
        GameObject.FindGameObjectWithTag("EventSystem").GetComponent<AudioManagement>().ExitSound();

        //lerp movement
        Vector3 valueToLerp;
        float camToLerp;
        float timeElapsed = 0;
        while (timeElapsed < 1)
        {
            //playerPos
            valueToLerp = Vector3.Lerp(player.transform.position, this.transform.position, timeElapsed / 1);
            player.transform.position = valueToLerp;

            //camZoom
            camToLerp = Mathf.Lerp(5f, 2.5f, timeElapsed / 1);
            player.transform.GetChild(0).GetComponent<Camera>().orthographicSize = camToLerp;

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        player.transform.position = this.transform.position;

        //scene
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("Fade").GetComponent<SceneFader>().FadeTo(3);
    }
}
