using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // VARIABLES---------------------------------------
    public GameObject WFCRoom;
    //private int hallwayLength = 2;  // units of 16 x 16 tiles

    public Transform startingPoint;

    private GameObject findHallwaySpawnPoint;

    private int direction;
    public int moveAmount;  // remeber to set this

    private void Start()
    {
        Instantiate(WFCRoom, startingPoint.position, Quaternion.identity);  // spawn in first room
    }

    private void spawnHallway()
    {
        // possible place the exit instead??
        findHallwaySpawnPoint = GameObject.Find("HSP"); // find and initialize where halllway will spawn

        // check direction to spawn hallway
        // check to make sure hall doesn't overlap a room somehow
        // regenerate exit if need be
    }

    //LEVEL_GENERATION----------------------------------------------------------------------------
    /*
    private void Move()
    {
        if (direction == 1 || direction == 2)   // move right
        {
            downCounter = 0;

            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos; // set level generation to this new position

            // generate room(WFC)
            Instantiate(WFCRoom, transform.position, Quaternion.identity);

            // so rooms don't spawn on each other   // idr what this does L
            direction = Random.Range(1, 5);
            if (direction == 3)
                direction = 2;
            else if (direction == 4)
                direction = 5;
        }
        else if (direction == 3 || direction == 4)   // move left
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
        else if (direction == 5) // move down
        {
            downCounter++;

            if (transform.position.y > minY)
            {
                // to make sure the path is not cut off
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room); // room so they only detect rooms not other objects w/colliders
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
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
    */
}
