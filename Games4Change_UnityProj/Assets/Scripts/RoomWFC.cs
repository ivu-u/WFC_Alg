using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWFC : MonoBehaviour    // simple tiled WFC
{
    // VARIABLES -----
    private static int roomDimension = 2;   // room tiles are square

    // create a 2D array of Dictionaries to simulate the room
    public Dictionary<string, GameObject>[,] roomMatrix = new Dictionary<string, GameObject>[roomDimension, roomDimension];

    // room tile rules
    

    // refrence the helpers
    public GameObject helperObject;
    HelperFunctions helperFunctions;
    public Dictionary<string, GameObject> filledDictionary;
    public bool finishedSuperposition = false;

    private void Start()
    {
        // copy filledDict into local var
        helperFunctions = helperObject.GetComponent<HelperFunctions>();
        filledDictionary = helperFunctions.filledDictionary;
    }

    public void Update()
    {
        Generate();
    }

    public void Generate()
    {
        if (!finishedSuperposition)
            SuperPosition();
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
    
}
