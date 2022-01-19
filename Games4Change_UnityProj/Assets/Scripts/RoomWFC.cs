using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomWFC : MonoBehaviour    // simple tiled WFC
{
    // VARIABLES -----
    public int dimension = 25;
    public static int roomDimension = 25;   // room tiles are square
    private int totalTiles = roomDimension*roomDimension;          // !!

    private bool superpositionDone = false;

    // create a 2D array of Dictionaries to simulate the room
    public Dictionary<string, GameObject>[,] roomMatrix = new Dictionary<string, GameObject>[roomDimension, roomDimension];
    bool[,] boolGeneratedMatrix = new bool[roomDimension, roomDimension];

    // entropy/selection vars
    List<int> lowestEntropyCoords = new List<int>();  // list of low entropy tile coords (x,y)
    private int chosenX;
    private int chosenY;

    // room tile rules
    public int exitsToGenerate = 1;
    public int entrancesToGenerate = 1;

    // refrence the helpers
    public GameObject helperObject;
    HelperFunctions helperFunctions;
    public Dictionary<string, GameObject> filledDictionary;

    private void Awake()
    {
        roomDimension = dimension;
    }

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
        Debug.Log("generation start");

        if (!superpositionDone)
            SuperPosition();
        Debug.Log("superposition done");

        //place any tiles manually here
        ForcePlace();

        bool doneGenerating = false;

        while (doneGenerating == false)
        {
            //loop through each tile and propagate (narrow down dictionary)
            for(int y = 0; y < roomDimension; y++)
            {
                for(int x = 0; x < roomDimension; x++)
                {
                    if (boolGeneratedMatrix[x, y] == false)
                    {
                        Propagate(x, y);
                        Debug.Log("propagate");
                    }
                }
            }
            //find the tile(s) with the smallest dictionaries
            findEntropy();
            Debug.Log("entropy found");
            //choose one of them
            chooseCoords();
            Debug.Log("coords chosen");
            Debug.Log("x: " + chosenX + " y: " + chosenY);
            //choose a tile to go there
            collapse(chosenX, chosenY); //leave 1 in dictionary
            Debug.Log("collapse");
            //check if every tile is "filled" - if it is, then stop the loop
            doneGenerating = checkGeneration();
        }
        Debug.Log("done generating");
        //put gameObjects in each spot with spawn();
        spawn();
    }

    private void ForcePlace ()
    {

    }

    private bool checkGeneration ()
    {
        bool pass = true;
        for(int x = 0; x < roomDimension; x++)
        {
            for(int y = 0; y < roomDimension; y++)
            {
                if(boolGeneratedMatrix[x,y] == false)
                {
                    pass = false;
                }
            }
        }
        return pass;
    }

    private void spawn()
    {
        for (int x = 0; x < roomDimension; x++)
        {
            for (int y = 0; y < roomDimension; y++)
            {
                Dictionary<string, GameObject> tile = roomMatrix[x, y];
                GameObject prefabToSpawn = tile.First().Value;
                Instantiate(prefabToSpawn, new Vector3(x, y, 0), prefabToSpawn.transform.rotation);
            }
        }
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
        superpositionDone = true;
    }

    private void findEntropy()  // find tile(s) with lowest entropy (the lowest number of possible solutions)
    {
        lowestEntropyCoords.Clear();    // clear list
        int lowestEntropyAmount = totalTiles;

        for (int x = 0; x < roomDimension; x++)
        {
            for (int y = 0; y < roomDimension; y++)
            {
                if (roomMatrix[x, y].Count < lowestEntropyAmount && boolGeneratedMatrix[x, y] == false)     // num of items in dict < LEA
                {
                    lowestEntropyAmount = roomMatrix[x, y].Count;   // set lowEA to new lowest entropy
                    lowestEntropyCoords.Clear();    // since there is a new lowest entropy clear the prev list coords
                    lowestEntropyCoords.Add(x);
                    lowestEntropyCoords.Add(y);     // add new x y coords to the list
                }
                else if (roomMatrix[x, y].Count == lowestEntropyAmount && boolGeneratedMatrix[x, y] == false)     //an item with equal entropy to lowestEA
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

    private void chooseCoords()
    {
        if (lowestEntropyCoords.Count == 2) // if only one choice
        {
            chosenX = lowestEntropyCoords[0];
            chosenY = lowestEntropyCoords[1];
        }
        else   // choose a random tile
        {
            int randNum = generateRandom();
            chosenX = lowestEntropyCoords[randNum];
            chosenY = lowestEntropyCoords[randNum + 1];
        }
    }

    public int generateRandom()
    {
        int randNum = Random.Range(0, lowestEntropyCoords.Count / 2);   // generate an even num
        randNum = randNum * 2;

        return randNum;
    }

    //only need to check neighbors of a collapsed tile, not every single one of them over and over?

    private void collapse (int x, int y)
    {
        int items = roomMatrix[x, y].Count;
        //take out tiles based on rules
        /*if (entrancesToGenerate == 0)
        {
            for(int i = items; i >= 0; i--)
            {
                if (roomMatrix[x, y].ElementAt(i).Value == filledDictionary.ElementAt(2).Value;
                {
                    roomMatrix[x, y].Remove(roomMatrix[x, y].ElementAt(i).Key);
                }
            }
        }
        if(exitsToGenerate == 0)
        {

        }*/

        //pick one randomly
        items = roomMatrix[x, y].Count;
        Debug.Log("count:" + items);
        if(items > 1)
        {
            int rnd = Random.Range(0, items - 1);
            Debug.Log("chosen tile:" + rnd);
            for (int i = items-1; i >= 0; i--)
            {
                if(i != rnd)
                {
                    roomMatrix[x, y].Remove(roomMatrix[x, y].ElementAt(i).Key);
                    Debug.Log("remove");
                }
                Debug.Log("dont remove");
            }
            Debug.Log("done removing");
        }
        Debug.Log(roomMatrix[x, y].Count);
        boolGeneratedMatrix[x, y] = true;
    }

    private void Propagate (int posX, int posY)
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

        if((posX >= 0 && posY + 1 < roomDimension))
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
        foreach (GameObject type in intersectAll)
        {
            allowedTiles.Add(type);
        }

        //allowedTile dictionary
        Dictionary<string, GameObject> newDictionary = new Dictionary<string, GameObject>();
        foreach(GameObject tile in allowedTiles)
        {
            newDictionary.Add(tile.name, tile);
        }
        //newDictionary = newDictionary.Intersect(filledDictionary);

        //pull out what isnt allowed from the tiles that ARE there

        roomMatrix[posX, posY] = newDictionary;

        /*List<GameObject> notAllowed = new List<GameObject>();

        foreach(KeyValuePair<string, GameObject> tile in filledDictionary)
        {
            bool found = false;
            foreach (GameObject candidate in allowedTiles)
            {
                if(tile.Value == candidate)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                notAllowed.Add(tile.Value);
            }
        }

        //need to return the tiles that aren't allowed from here
        string result = "Final not allowed: ";
        foreach (GameObject z in notAllowed)
        {
            result += (z.name + ", ");
        }*/
    }
}
