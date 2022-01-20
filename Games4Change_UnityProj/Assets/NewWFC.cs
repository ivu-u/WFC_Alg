using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWFC : MonoBehaviour
{
    public static int roomDimension;
    //2d array of x,y to hold information for each tile until it is spawned
    public NewTile[,] roomMatrix = new NewTile[roomDimension, roomDimension];

    //queue to hold items to propagate
    //bool for if all the tiles are generated


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
            Propagate();
            //Find Entropy - find the lowest entropy(s) and place their coordinates in a list (list of arrays)
            FindEntropy();
            //Choose Coordinates - take the previous list of coordinates and select a random one to generate at (pick a random array from list)
            //Collapse - collapse the array position (x,y) from the previous function by randomly picking an available tile and add neighbors of the (x,y) to the queue
            //check generation - see if all tiles have been generated
    }

    void InitializeSuperPositions ()
    {
        //this script will set every gameobject in roommatrix with default values based on their (x,y) and filling all possible states
    }

    void ForcePlace ()
    {
        //eseentially collapse but specific tile in specific place
    }

    void Propagate ()
    {
        //while queue length is greater than 0
            //save item in queue (x,y) to appropriate tileVar
            //pop queue to remove that posiion 
            //check what is Allowed to be there - bool dirty = crossOff();
            //if it came back dirty (crossed something off)
                //add the tile's neighbors to the propagate queue
    }

    bool CrossOff (NewTile tile)
    {
        bool dirtyReturn = false;
        //get tile to the up, down, left, right
        //get intersection of what all of those are allowed for this tiles position - set that to possibilities
        //update new possibilities based on that (new variable)
            //for each tile in possiblities
                //tileplacementrules.getAllowed("tileType", "direction");
        //if newPossiblities count is less than old possiblities count
            //set dirtyReturn to true
        //update what is allowed to the right, left, up, down based on if possibilities got updated
        return dirtyReturn;
    }

    List<int> FindEntropy ()
    {
        //list of coords with the lowest entropy
        List<int> coords = new List<int>();
        //clear list
        //
        //return coordinates list
        return coords;
    }

    int[] ChooseCoordinates()
    {
        //coordinate array to return
        int [] f = new int[2];

        //return coordinates
        return f;
    }
}
