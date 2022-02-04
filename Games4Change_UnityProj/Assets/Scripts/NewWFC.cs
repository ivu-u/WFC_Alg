using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewWFC : MonoBehaviour
{
    HelperFunctions help;

    public int roomDimension;
    //2d array of x,y to hold information for each tile until it is spawned
    public NewNode[,] roomMatrix;
    int totalTiles;
    int generated = 0;

    //array for filled list
    public NewTileTemplate[] filledList;

    // queue for dirty tiles
    Stack<NewNode> dirty = new Stack<NewNode>();
    Queue<NewNode> genOrder = new Queue<NewNode>();
    public bool canGo = false;

    // Start is called before the first frame update
    void Start()
    {
        help = this.GetComponent<HelperFunctions>();
        roomMatrix = new NewNode[roomDimension, roomDimension];
        totalTiles = roomDimension * roomDimension;
        Generate();
        //Debug.Log(roomMatrix.Length);
    }

    void Generate ()
    {
        //Initialzie all the nodes - go through array filling all possibilities (superpositions)
        InitializeSuperPositions();

        //Place any states manually in the nodes before wave function generation starts (collapse to 1)
        ForcePlace(); //constrain to (single) vs constrain from (remove 1)

        while (generated < totalTiles)
        {
            //Propagate - cross off all the things in the queue
            Propagate();

            //Find Entropy - find the lowest entropy(s) and place their coordinates in a list (list of arrays)
            List<int> coordList = FindEntropy();

            //Choose Coordinates - take the previous list of coordinates and select a random one to generate at (pick a random array from list)
            int[] coordToCollapse = ChooseCoordinates(coordList);

            //Collapse - collapse the array position (x,y) from the previous function by randomly picking an available tile and add neighbors of the (x,y) to the queue
            Collapse(coordToCollapse);
        }

        this.gameObject.GetComponent<TilePainter>().makeTiles(genOrder);

        help.dumpMatrix(roomMatrix);
        
    }

    void InitializeSuperPositions ()
    {
        //this script will set every gameobject in roommatrix with default values based on their (x,y) and filling all possible states
        for(int y = 0; y < roomDimension; y++) 
        {
            for(int x = 0; x < roomDimension; x++) 
            {
                roomMatrix[y, x] = new NewNode(y, x);
            }
        }
    }

    void ForcePlace ()
    {
        //essentially collapse a specific state to a specific node in specific place
        string[] initial = { "voidTile" };
        roomMatrix[0, 0].possibilities = new HashSet<string>(initial);
        roomMatrix[0, 0].updateAdjacency();
        roomMatrix[0, 0].isCollapsed = true;
        roomMatrix[0, 0].label = "voidTile";
        dirty.Push(roomMatrix[1, 0]);
        dirty.Push(roomMatrix[0, 1]);
        genOrder.Enqueue(roomMatrix[0, 0]);

        generated++;
        this.GetComponent<TilePainter>().spawnTiles(roomMatrix[0, 0]);
    }

    void Propagate ()
    {
        while (dirty.Count > 0)
        {
            // save (x,y) value of node to use later
            int x = dirty.Peek().positionX;
            int y = dirty.Peek().positionY;

            dirty.Pop();    //pop stack to remove that posiion 
            CrossOff(y, x);
        }
    }

    bool CrossOff (int y, int x)
    {
        bool dirtyReturn = false;
        string[] full = { "groundTile", "wallTile", "exitTile", "entranceTile", "voidTile" };
        HashSet<string> newPossibilities = new HashSet<string>(full);

        //get node to the up, down, left, right
        bool above = false;
        bool below = false;
        bool left = false;
        bool right = false;

        if(x-1 >= 0)
        {
            left = true;
        }
        if(x+1 < roomDimension)
        {
            right = true;
        }
        if(y-1 >= 0)
        {
            above = true;
        }
        if(y+1 < roomDimension)
        {
            below = true;
        }

        //get intersection of what all of those are allowed for this node's position - set that to newPossibilities
        //update newPossibilities based on that (new variable)
        if (above)
        {
            newPossibilities.IntersectWith(roomMatrix[y - 1, x].allowedBelowThisNode);
        }
        if (below)
        {
            newPossibilities.IntersectWith(roomMatrix[y + 1, x].allowedAboveThisNode);
        }
        if (left)
        {
            newPossibilities.IntersectWith(roomMatrix[y, x-1].allowedRightThisNode);
        }
        if (right)
        {
            newPossibilities.IntersectWith(roomMatrix[y, x+1].allowedLeftThisNode);
        }

        //if newPossiblities count is less than old possiblities count
        //set dirtyReturn to true
        if (newPossibilities.Count != roomMatrix[y, x].possibilities.Count)
        {
            dirtyReturn = true;
            
        }
        roomMatrix[y, x].possibilities = newPossibilities;
        roomMatrix[y, x].updateAdjacency();

        //update what is allowed to the right, left, up, down based on if possibilities got updated (dirty is true)
        if (dirtyReturn == true)
        {
            if(above && roomMatrix[y-1, x].isCollapsed == false)
            {
                dirty.Push(roomMatrix[y - 1, x]);
            }
            if(below && roomMatrix[y + 1, x].isCollapsed == false)
            {
                dirty.Push(roomMatrix[y + 1, x]);
            }
            if(left && roomMatrix[y, x - 1].isCollapsed == false)
            {
                dirty.Push(roomMatrix[y, x - 1]);
            }
            if(right && roomMatrix[y, x + 1].isCollapsed == false)
            {
                dirty.Push(roomMatrix[y, x + 1]);
            }
        }
        return dirtyReturn;
    }

    List<int> FindEntropy ()
    {
        //list of coords with the lowest entropy
        List<int> coords = new List<int>();
        
        int lowestEntropy = 100;    // random high number
        for (int y = 0; y < roomDimension; y++)
        {
            for (int x = 0; x < roomDimension; x++)
            {
                if (roomMatrix[y,x].isCollapsed == false && roomMatrix[y,x].possibilities.Count == 1) // if there is only 1 possibility collapse
                {
                    int[] array = new int[] {y, x};
                    Collapse(array);
                }
                else if (roomMatrix[y,x].isCollapsed == false && roomMatrix[y,x].possibilities.Count < lowestEntropy) // new lowest entropy tile
                {
                    coords.Clear();

                    coords.Add(y);
                    coords.Add(x);
                    lowestEntropy = roomMatrix[y,x].possibilities.Count;
                }
                else if (roomMatrix[y,x].isCollapsed == false && roomMatrix[y,x].possibilities.Count == lowestEntropy)    // equal entropy
                {
                    coords.Add(y);
                    coords.Add(x);
                }
            }
        }
        Debug.Log("Lowest entropy: " + lowestEntropy);
        return coords;
    }

    int[] ChooseCoordinates(List<int> lowestEntropyCoords)
    {
        //coordinate array to return
        int [] f = new int[2];

        
        if (lowestEntropyCoords.Count == 2) // if only one choice
        {
            f[0] = lowestEntropyCoords[0];
            f[1] = lowestEntropyCoords[1];
        }
        else   // choose a random tile
        {
            int randNum = generateRandom(lowestEntropyCoords);
            f[0] = lowestEntropyCoords[randNum];
            f[1] = lowestEntropyCoords[randNum + 1];
        }
        return f;
    }

    public int generateRandom(List<int> lowestEntropyCoords)
    {
        int randNum = Random.Range(0, lowestEntropyCoords.Count / 2);   // generate an even num
        randNum = randNum * 2;

        return randNum;
    }

    void Collapse(int[] coordinateToCollapse)
    {
        int y = coordinateToCollapse[0];
        int x = coordinateToCollapse[1];
        //get possiblities of coordinate
        CrossOff(y, x);
        //randomly pick 1
        string choice;
        int randNum = Random.Range(0, roomMatrix[y,x].possibilities.Count);
        choice = roomMatrix[y,x].possibilities.ElementAt(randNum);

        //cross out all but that possiblity
        roomMatrix[y,x].possibilities = new HashSet<string>();
        roomMatrix[y,x].possibilities.Add(choice);
        genOrder.Enqueue(roomMatrix[y, x]);
        
        //update node label
        roomMatrix[y,x].label = choice;

        //update node generation bool
        roomMatrix[y,x].isCollapsed = true;

        //update what is allowed on each side of the node (call a function on it that gets the rules from the master list - string to state)
        roomMatrix[y,x].updateAdjacency();

        //add adjacent tiles to the stack
        bool above = false;
        bool below = false;
        bool left = false;
        bool right = false;

        if(x-1 >= 0)
        {
            left = true;
        }
        if(x+1 < roomDimension)
        {
            right = true;
        }
        if(y-1 >= 0)
        {
            above = true;
        }
        if(y+1 < roomDimension)
        {
            below = true;
        }

        if(above && roomMatrix[y - 1, x].isCollapsed == false)
        {
            dirty.Push(roomMatrix[y - 1, x]);
        }
        if(below && roomMatrix[y + 1, x].isCollapsed == false)
        {
            dirty.Push(roomMatrix[y + 1, x]);
        }
        if(left && roomMatrix[y, x - 1].isCollapsed == false)
        {
            dirty.Push(roomMatrix[y, x - 1]);
        }
        if(right && roomMatrix[y, x + 1].isCollapsed == false)
        {
            dirty.Push(roomMatrix[y, x + 1]);
        }

        //this.GetComponent<TilePainter>().spawnTiles(roomMatrix[y, x]);
        canGo = false;
        
        //update generated count
        generated++;

        //paint
        //this.gameObject.GetComponent<TilePainter>().spawnTiles(roomMatrix[y,x]);
    }
}
