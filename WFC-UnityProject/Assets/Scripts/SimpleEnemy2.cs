using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy2 : MonoBehaviour
{
    private float dirX;
    private float dirY;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    private bool facingRight = false;
    private bool facingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        dirY = -1f;
        rb.velocity = new Vector2(dirX * moveSpeed, 0 * moveSpeed);
        dirX = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wallTile")
        {
            switchDirection();
            Debug.Log("hit");
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().Die();
        }
    }

    void switchDirection()
    {
        int randNum = Random.Range(1, 3);

        if (randNum == 1)
        {
            Debug.Log("x1: " + dirX);

            if (dirX > 0)
                facingRight = true;
            else if (dirX < 0)
                facingRight = false;

            if (((facingRight) && (dirX > 0)) || ((!facingRight) && (dirX < 0)))
            {
                Debug.Log("changedirX");
                dirX *= -1;
            }

            rb.velocity = new Vector2(dirX * moveSpeed, 0 * moveSpeed);

            Debug.Log("x: " + dirX);
        }
        else if (randNum == 2)
        {
            Debug.Log("y1: " + dirY);

            // check for Y direction
            if (dirY > 0)
                facingUp = true;
            else if (dirY < 0)
                facingUp = false;

            if (((facingUp) && (dirY > 0)) || ((!facingUp) && (dirY < 0)))
            {
                Debug.Log("changedirY");
                dirY *= -1;
            }

            rb.velocity = new Vector2(0 * moveSpeed, dirY * moveSpeed);

            Debug.Log("y: " + dirY);
        }
    }
}
