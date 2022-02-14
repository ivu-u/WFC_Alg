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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wallTile")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z+90f);
            Debug.Log("wallHit");
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Die();
        }
    }

    private void Update()
    {
        rb.AddForce(transform.up * moveSpeed * Time.deltaTime);
    }
}
