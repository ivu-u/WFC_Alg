using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy3 : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 localScale;
    private Rigidbody2D rb;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wallTile")
        {
            transform.Rotate(0, 0, 90);
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().Die();
        }
    }

    private void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
    }
}
