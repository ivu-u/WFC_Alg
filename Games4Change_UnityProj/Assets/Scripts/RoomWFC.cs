using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWFC : MonoBehaviour    // simple tiled WFC
{
    // VARIABLES -----
    private static int roomDimension = 4;   // room tiles are square

    // create a 2D array of Dictionaries to simulate the room
    public Dictionary<string, GameObject>[,] roomMatrix = new Dictionary<string, GameObject>[roomDimension, roomDimension];

    // room tile rules
    public bool isFirst;    // is this the first room generated

    // refrence the helpers
    public GameObject helperObject;
    HelperFunctions helperFunctions;
    public Dictionary<string, GameObject> filledDictionary;

    private void Start()
    {
        // initialize filled dictionary
        helperFunctions = helperObject.GetComponent<HelperFunctions>();
        //filledDictionary = 
    }

    public void Generate()
    {

    }

    private void SuperPosition()    // fill all tiles with all possible solutions
    {
        for (int x = 0; x < roomDimension; x++)
        {
            for (int y = 0; y < roomDimension; y++)
            {

            }
        }
    }
    
}
