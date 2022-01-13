using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWFC : MonoBehaviour    // simple tiled WFC
{
    // VARIABLES -----
    private static int roomDimension = 2;   // room tiles are square
    private int totalTiles = 5;          // !!

    // create a 2D array of Dictionaries to simulate the room
    public Dictionary<string, GameObject>[,] roomMatrix = new Dictionary<string, GameObject>[roomDimension, roomDimension];

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

    public void Update(){
        Generate();
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
    
}
