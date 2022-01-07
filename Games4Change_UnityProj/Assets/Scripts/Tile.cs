using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header ("Allowed Above")]
    public GameObject[] aboveList;

    [Header("Allowed Below")]
    public GameObject[] aboveBelow;

    [Header("Allowed Left")]
    public GameObject[] leftList;

    [Header("Allowed Right")]
    public GameObject[] rightList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
