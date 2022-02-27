using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    public float runSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //get input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //rotate sprite accordingly
        if(vertical < 0)
        {
            this.GetComponent<SpriteRenderer>().flipY = false;
        } else if (vertical > 0)
        {
            this.GetComponent<SpriteRenderer>().flipY = true;
        }

        if(horizontal > 0)
        {
            transform.localScale = new Vector3(.5f, .5f, 1f);
        } else if(horizontal < 0)
        {
            transform.localScale = new Vector3(-.5f, .5f, 1f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void Die()
    {
        StartCoroutine(Death());
    }

    public IEnumerator Death()
    {
        //sprite
        this.GetComponent<Animator>().SetBool("dead", true);

        //freeze movement
        runSpeed = 0;

        //freeze enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<SimpleEnemy3>().moveSpeed = 0;
        }

        //play sounds
        GameObject.FindGameObjectWithTag("EventSystem").GetComponent<AudioManagement>().SplatSound();

        //scene
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("Fade").GetComponent<SceneFader>().FadeTo(2);
    }
}
