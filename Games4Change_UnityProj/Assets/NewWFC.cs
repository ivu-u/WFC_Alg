using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWFC : MonoBehaviour
{
    public static int roomDimension;
    //2d array of x,y to hold information for each tile until it is spawned
    public NewNode[,] roomMatrix = new NewNode[roomDimension, roomDimension];

    //queue/stack to hold items to propagate (dirty things to check)
    //bool for if all the nodes are generated

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate ()
    {
        //Initialzie all the nodes - go through array filling possibility list and allowed NEWS
        InitializeSuperPositions();
        //Place any states manually in the nodes before wave function generation starts
        ForcePlace(); //constrain to (single) vs constrain from (remove 1)
        //While not fully generated: 
            //Propagate - cross off all the things in the queue
            Propagate();
            //Find Entropy - find the lowest entropy(s) and place their coordinates in a list (list of arrays)
            FindEntropy();
            //Choose Coordinates - take the previous list of coordinates and select a random one to generate at (pick a random array from list)
            //Collapse - collapse the array position (x,y) from the previous function by randomly picking an available tile and add neighbors of the (x,y) to the queue
            //check generation - see if all nodes have been filled with a state
    }

    void InitializeSuperPositions ()
    {
        //this script will set every gameobject in roommatrix with default values based on their (x,y) and filling all possible states
    }

    void ForcePlace ()
    {
        //eseentially collapse a specific state to a specific node in specific place
    }

    void Propagate ()
    {
        //while queue length is greater than 0
            //save item in queue (x,y) to appropriate nodeVar
            //pop queue to remove that posiion 
            //check what is Allowed to be there - bool dirty = crossOff();
            //if it came back dirty (crossed something off)
                //add the node's neighbors to the propagate queue
    }

    bool CrossOff (NewNode node)
    {
        bool dirtyReturn = false;
        //get node to the up, down, left, right
        //get intersection of what all of those are allowed for this node's position - set that to newPossibilities
        //update newPossibilities based on that (new variable)
            //for each node in possiblities
                //tileplacementrules.getAllowed("tileType", "direction"); -- is this the same as the second to last line in this function
        //if newPossiblities count is less than old possiblities count
            //set dirtyReturn to true
        //update what is allowed to the right, left, up, down based on if possibilities got updated (dirty is true)
        return dirtyReturn;
    }

    List<int> FindEntropy ()
    {
        //list of coords with the lowest entropy
        List<int> coords = new List<int>();
        //clear list
        //int for lowest entropyAmount that is set to 100 or something initially
        //loop x
            //loop y
                //if (x,y).node.possibilities < entropyAmount
                    //clear the list
                    //add this coordinate to list
                //if (x,y).node.possibilities == entropyAmount
                    //add this coordinate to list
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
