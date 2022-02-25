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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
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


        //scene
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("Fade").GetComponent<SceneFader>().FadeTo(2);
    }
}
