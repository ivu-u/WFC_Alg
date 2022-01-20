using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWFC : MonoBehaviour
{
    public static int roomDimension;
    //2d array of x,y to hold information for each tile until it is spawned
    public NewTile[,] roomMatrix = new NewTile[roomDimension, roomDimension];

    //queue to hold items to propagate


    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate ()
    {
        //Initialzie all the tiles
        InitializeSuperPositions();
        //Place any tiles manually before wave function generation starts
        ForcePlace();
        //While not fully generated: 
            //Propagate - cross off all the things in the queue
            //Find Entropy - find the lowest entropy(s) and place their coordinates in a list (list of arrays)
            //Choose Coordinates - take the previous list of coordinates and select a random one to generate at (pick a random array from list)
            //Collapse - collapse the array position (x,y) from the previous function by randomly picking an available tile and add neighbors of the (x,y) to the queue
    }

    void InitializeSuperPositions ()
    {
        //this script will set every gameobject in roommatrix with default values based on their (x,y) and filling all possible states
    }

    void ForcePlace ()
    {

    }

    void Propagate ()
    {
        //while queue length is greater than 1
            //save item in queue to tileVar
            //pop queue
            //check what is Allowed to be there - bool dirty = tileVar.crossOff();
            //if it came back dirty (crossed something off)
                //add the tile's neighbors to the propagate queue
    }
}
