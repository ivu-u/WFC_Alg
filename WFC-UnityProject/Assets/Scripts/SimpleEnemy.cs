using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    private float dirX;
    private float dirY;
    public float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private bool facingUp = false;
    private Vector3 localScale;

    private bool isX = false;
    private bool isY = false;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        dirY = -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wallTile")
        {
            dirX *= -1f;
            dirY *= -1f;
        }

        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().Die();
        }
    }

    void FixedUpdate()
    {
        Debug.Log("called here");
        if (isX)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, moveSpeed);
        }
        else if (isY)
        {
            rb.velocity = new Vector2(moveSpeed, dirY * moveSpeed);
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        int randNum = Random.Range(1, 3);

        if (randNum == 1)
        {
            isX = true;
            isY = false;

            // check for X direction
            if (dirX > 0)
                facingRight = true;
            else if (dirX < 0)
                facingRight = false;

            if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
                localScale.x *= -1;
        }
        else if (randNum == 2)
        {
            isX = false;
            isY = true;

            // check for Y direction
            if (dirY > 0)
                facingUp = true;
            else if (dirY < 0)
                facingUp = false;

            if (((facingUp) && (localScale.y < 0)) || ((!facingUp) && (localScale.y > 0)))
                localScale.y *= -1;
        }
        transform.localScale = localScale;
    }
}
