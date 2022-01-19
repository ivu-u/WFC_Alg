using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLevelGeneration : MonoBehaviour
{
    // VARIABLES---------------------------------------
    // array of starting positions
    public Transform[] startingPositions;
    public GameObject[] rooms;  // ind 0 -> LR, ind 1 -> LRB, ind 2 ->, ind 3 -> LRBT

    private int direction; // to create a path
    public float moveAmount;

    // variables for spaning rooms
    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    // variables for keeping level generation boundaries
    public float minX;
    public float maxX;
    public float minY;
    public bool stopGen;

    public LayerMask room;

    private int downCounter;

    // for player spawnpoint
    public Transform player;

    private void Start()
    {
        // generate a random tarting position
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;   // place room in that position
        Instantiate(rooms[0], transform.position, Quaternion.identity);     //spwn room

        direction = Random.Range(1, 6); // generate a rand int between 1 and 5

        // spawn player spawnpoint
        player.position = startingPositions[randStartingPos].position;
    }

    //SPAWNING_ROOMS-------------------------------------------------------------------------------
    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGen == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    //LEVEL_GENERATION----------------------------------------------------------------------------
    private void Move()
    {
        if (direction == 1 || direction == 2)   // move right
        {
            // check level generation boundaries
            if (transform.position.x < maxX)
            {
                downCounter = 0;

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos; // set level generation to this new position

                // generate a random room
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                // so rooms don't spawn on each other
                direction = Random.Range(1, 5);
                if (direction == 3)
                    direction = 2;
                else if (direction == 4)
                    direction = 5;
            }
            else
                direction = 5;  // move down
        }
        else if (direction == 3 || direction == 4)   // move left
        {
            // check level gen boundaries
            if (transform.position.x > minX)
            {
                downCounter = 0;

                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos; // set level generation to this new position

                // generate a random room
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                // so rooms don't spawn on each other
                direction = Random.Range(3, 6);
            }
            else
                direction = 5;  // move down
        }
        else if (direction == 5) // move down
        {
            downCounter++;

            if (transform.position.y > minY)
            {
                // to make sure the path is not cut off
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room); // room so they only detect rooms not other objects w/colliders
                if (roomDetection.GetComponent<RoomType>().type !=1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    // if move down twice, spawn room with openings on all sides
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        // spawn a room with a bottom opening
                        int randBottom = Random.Range(1, 4);
                        if (randBottom == 2)
                            randBottom = 1;

                        Instantiate(rooms[randBottom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos; // set level generation to this new position

                // rooms must have a top opening
                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                // room can spawn anywhere when gen down
                direction = Random.Range(1, 6);
            }
            else
            {
                // stop level gen
                stopGen = true;
            }
        }
    }
}
