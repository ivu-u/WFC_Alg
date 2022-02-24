using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy3 : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 localScale;
    private Rigidbody2D rb;
    public float backJump;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wallTile" || collision.gameObject.tag == "enemy")
        {
            // Get current directioh
            Vector3 backVel = transform.up * -1;
            backVel = new Vector3(backVel.x / backJump, backVel.y / backJump, backVel.z / backJump);
            transform.position = transform.position + backVel;
            rb.velocity = new Vector2(0, 0);

            //this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            int dir = Random.Range(0, 2);
            Quaternion rotAmount;
            if (dir == 1)
            {
                //turn right
                rotAmount = Quaternion.Euler(0, 0, 90);
            } else
            {
                //turn left
                rotAmount = Quaternion.Euler(0, 0, -90);
            }
            
            transform.rotation = transform.rotation * rotAmount;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Die();
        }
    }

    private void Update()
    {
        Vector3 forVel = transform.up;
        rb.velocity = new Vector3(forVel.x * moveSpeed, forVel.y * moveSpeed, forVel.z * moveSpeed);
    }
}
