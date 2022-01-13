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

    // entropy/selection vars
    List<int> lowestEntropyCoords = new List<int>();  // list of low entropy tile coords (x,y)
    private int chosenX;
    private int chosenY;

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
    }

    public void Generate()  // starter
    {
        if (!finishedSuperposition)
            SuperPosition();

        findEntropy();
        
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
        lowestEntropyCoords.Clear();    // clear list
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
                    lowestEntropyCoords.Add(x);
                    lowestEntropyCoords.Add(y);
                }
                else    // > lowest entropy
                {
                    // do nothing
                }
            }
        }
    }

    private void chooseTile()
    {
        if (lowestEntropyCoords.Count == 2)
        {
            // since there is only one option just use those coords
            chosenX = lowestEntropyCoords[0];
            chosenY = lowestEntropyCoords[1];
        }
        else
        {
            // since there are multiple options ranomly choose one
            int randNum = generateRandom();
            chosenX = randNum;
            chosenY = randNum + 1;
        }
    }

    public int generateRandom()
    {
        int randNum = Random.Range(0, 4 / 2);//lowestEntropyCoords.Count
        randNum = randNum * 2;

        return randNum;
    }

    private void Collapse (int posX, int posY)
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
        foreach (GameObject type in intersectAll)
        {
            allowedTiles.Add(type);
        }

        //need to return the tiles that aren't allowed from here
    }
}
