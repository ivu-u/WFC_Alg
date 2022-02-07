using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    private void Start() 
    {
        // spawn first room (connected to an empty game object)
        // change WFC script so the first tile spawns at empty game object.pos
    }
    
    public void continueFloorGeneration()
    {
        // will be called once room 1 from the WFC is completed.
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