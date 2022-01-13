using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomWFC : MonoBehaviour    // simple tiled WFC
{
    // VARIABLES -----
    private static int roomDimension = 2;   // room tiles are square
    private int totalTiles = 5;          // !!

    // create a 2D array of Dictionaries to simulate the room
    public Dictionary<string, GameObject>[,] roomMatrix = new Dictionary<string, GameObject>[roomDimension, roomDimension];
    bool[,] boolGeneratedMatrix = new bool[roomDimension, roomDimension];

    // room tile rules
    

    // refrence the helpers
    public GameObject helperObject;
    HelperFunctions helperFunctions;
    public Dictionary<string, GameObject> filledDictionary;
    private bool finishedSuperposition = false;

    private void Start()
    {

        // copy filledDict into local var
        helperFunctions = helperObject.GetComponent<HelperFunctions>();
        filledDictionary = helperFunctions.filledDictionary;
        Generate();
    }

    public void Update(){
    }

    public void Generate()  // starter
    {
        if (!finishedSuperposition)
            SuperPosition();

        //findEntropy();
        roomMatrix[0, 0] = helperFunctions.testDictionary;
        Collapse(1, 0);
    }

    private void SuperPosition()    // fill all tiles with all possible solutions
    {
        for (int x = 0; x < roomDimension; x++)
        {
            for (int y = 0; y < roomDimension; y++)
            {
                roomMatrix[x, y] = filledDictionary;
                Debug.Log("Filled: " + x + " " + y);
            }
        }
        finishedSuperposition = true;
    }

    private void findEntropy()  // find tile with lowest entropy (the lowest number of possible solutions)
    {
        List<int> lowestEntropyCoords = new List<int>();  // save x y coords of cell with lowest entropy
        int lowestEntropyAmount = totalTiles;

        for (int x = 0; x < roomDimension; x++)
        {
            for (int y = 0; y < roomDimension; y++)
            {
                if (roomMatrix[x, y].Count < lowestEntropyAmount)     // num of items in dict < LEA
                {
                    lowestEntropyAmount = roomMatrix[x, y].Count;   // set lowEA to new lowest entropy
                    lowestEntropyCoords.Clear();    // since there is a new lowest entropy clear the prev list coords
                    lowestEntropyCoords.Add(x);
                    lowestEntropyCoords.Add(y);     // add new x y coords to the list
                }
                else if (roomMatrix[x, y].Count == lowestEntropyAmount)     //an item with equal entropy to lowestEA
                {

                }
            }
        }
    }

    private List<GameObject> Collapse (int posX, int posY)
    {
        bool topTile = false;
        bool leftTile = false;
        bool rightTile = false;
        bool bottomTile = false;

        if(posX >= 0 && posY - 1 >= 0)
        {
            topTile = true;
        }

        if(posX -1 >= 0 && posY >= 0)
        {
            leftTile = true;
        }

        if(posX + 1 < roomDimension && posY >= 0)
        {
            rightTile = true;
        }

        if((posX >= 0 && posY + 1 < roomDimension) && boolGeneratedMatrix[posX, posY+1] == true)
        {
            bottomTile = true;
        }

        Debug.Log(topTile);
        Debug.Log(leftTile);
        Debug.Log(rightTile);
        Debug.Log(bottomTile);

        //top and left - a
        List<GameObject> a = new List<GameObject>();
        if (topTile && leftTile)
        {
            //top
            GameObject[] top = roomMatrix[posX, posY-1].First().Value.GetComponent<Tile>().aboveBelow;

            //left
            GameObject[] left = roomMatrix[posX - 1, posY].First().Value.GetComponent<Tile>().rightList;

            //intersect
            var intersectTopLeft = top.Intersect(left);
            foreach (GameObject type in intersectTopLeft) {
                a.Add(type);
            }
        } else if(topTile)
        {
            GameObject[] top = roomMatrix[posX, posY - 1].First().Value.GetComponent<Tile>().aboveBelow;
            foreach (GameObject type in top)
            {
                a.Add(type);
            }
        } else if(leftTile)
        {
            GameObject[] left = roomMatrix[posX - 1, posY].First().Value.GetComponent<Tile>().rightList;
            foreach (GameObject type in left)
            {
                a.Add(type);
                Debug.Log("right list: " + type.name);
            }
        }

        //right and bottom - b
        List<GameObject> b = new List<GameObject>();
        if (rightTile && bottomTile)
        {
            //right
            GameObject[] right = roomMatrix[posX + 1, posY].First().Value.GetComponent<Tile>().leftList;

            //bottom
            GameObject[] bottom = roomMatrix[posX, posY+1].First().Value.GetComponent<Tile>().aboveList;

            //intersect
            var intersectBottomRight = right.Intersect(bottom);
            foreach (GameObject type in intersectBottomRight)
            {
                b.Add(type);
            }
        }
        else if (rightTile)
        {
            GameObject[] right = roomMatrix[posX + 1, posY].First().Value.GetComponent<Tile>().leftList;
            foreach (GameObject type in right)
            {
                b.Add(type);
            }
        }
        else if (bottomTile)
        {
            GameObject[] bottom = roomMatrix[posX, posY + 1].First().Value.GetComponent<Tile>().aboveList;
            foreach (GameObject type in bottom)
            {
                b.Add(type);
            }
        }

        //combo of a and b
        List<GameObject> allowedTiles = new List<GameObject>();
        var intersectAll = a.Intersect(b);
        if (a.Any() && b.Any())
        {
            intersectAll = a.Intersect(b);
        } else if (a.Any())
        {
            intersectAll = a;
        } else
        {
            intersectAll = b;
        }
        string j = "Final allowed: ";
        foreach (GameObject type in intersectAll)
        {
            allowedTiles.Add(type);
            j += type.name;
        }
        Debug.Log(j);

        List<GameObject> notAllowed = new List<GameObject>();

        foreach(KeyValuePair<string, GameObject> tile in filledDictionary)
        {
            bool found = false;
            foreach (GameObject candidate in allowedTiles)
            {
                if(tile.Value == candidate)
                {
                    found = true;
                }
                if(found == false)
                {
                    notAllowed.Add(tile.Value);
                }
            }
        }

        //need to return the tiles that aren't allowed from here
        string result = "Final not allowed: ";
        foreach (GameObject z in notAllowed)
        {
            result += z.name + ", ";
        }
        Debug.Log(result);
            
        return notAllowed;
    }
}
