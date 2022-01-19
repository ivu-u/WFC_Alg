using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWFC : MonoBehaviour
{
    public static int roomDimension;
    public GameObject[,] roomMatrix = new GameObject[roomDimension, roomDimension];

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate ()
    {
        InitializeSuperPositions();
        ForcePlace();
    }

    void InitializeSuperPositions ()
    {
        //this script will set every gameobject in roommatrix with default values based on their (x,y) and filling all possible states
    }

    void ForcePlace ()
    {

    }
}
