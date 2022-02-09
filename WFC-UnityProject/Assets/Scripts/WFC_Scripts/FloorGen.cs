using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    // VARIABLES ----------
    public GameObject roomWFCPrefab;

    private void Start() 
    {
        // spawn first room (connected to an empty game object)
        Instantiate(roomWFCPrefab, new Vector3(0, 0, 0), Quaternion.identity);  // pos at (0,0)

        // change WFC script so the first tile spawns at empty game object.pos
    }

    // right now we are creating a superposition list of all nodes (already defined with their x y posotions)
    // then we change the tile that goes in that node
    // maybe we can spawn the room at the position of an empty, and then iterate all other positions by the tile size
    
    public void continueFloorGeneration()
    {
        // will be called once room 1 from the WFC is completed.
        spawnHallway();
        spawnRoom();
        checkFloorGeneration();
    }

    private void spawnHallway()
    {
        // where exit is check if hallway can spawn
            // check the possible hallway location and check if it's empty
            // check the possible room location (rooom size collider) to see if the room fits
            // if yes spawn the hallway
            // instantiate prefab & direction

            // if not try another exit from the original room an delete this exit
    }

    private void spawnRoom()
    {
        // spawn next room (connected to hallway)
        // instatntiate the roomWFC prefab to generate the new room (?)
        // here might be where we define the room type too..
    }

    private void checkFloorGeneration()
    {
        // room generation rules:
        // must me a minimum number of room types that have spawned before generation ends
        // must be at least X rooms total 

        // if all room rules are fulfilled then end generation (or chance to end generation)
    }
}