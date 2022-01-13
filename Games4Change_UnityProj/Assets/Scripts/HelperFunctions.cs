using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions : MonoBehaviour
{
    // make a dictionary that contains all possible solutions
    public Dictionary<string, GameObject> filledDictionary = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> testDictionary = new Dictionary<string, GameObject>();

    // drag in tiles
    [Header("Tiles")]
    public GameObject wall_tile;
    public GameObject floor_tile;
    public GameObject exit_tile;
    public GameObject entry_tile;
    public GameObject void_tile;

    private void Start()    // initialize filled dictionary
    {
        //filled
        filledDictionary.Add("wall_tile", wall_tile);
        filledDictionary.Add("floor_tile", floor_tile);
        filledDictionary.Add("exit_tile", exit_tile);
        filledDictionary.Add("entry_tile", entry_tile);
        filledDictionary.Add("void_tile", void_tile);

        //test
        testDictionary.Add("void_tile", void_tile);
    }



    //OLD CODE FOR MANY TILES------------------------------

    /*
    // drag in each corresponding tile
    [Header("Corners")]
    public GameObject Corner_TL;
    public GameObject Corner_TR;
    public GameObject Corner_BL;
    public GameObject Corner_BR;

    [Header("Walls")]
    public GameObject Wall_T;
    public GameObject Wall_B;
    public GameObject Wall_L;
    public GameObject Wall_R;

    [Header("Other")]
    public GameObject full_void;
    public GameObject full_wall;

    // when the game start create this filled dictionary
    private void Start()
    {
        
        // corners
        filledDictionary.Add("Corner_TL", Corner_TL);
        filledDictionary.Add("Corner_TR", Corner_TR);
        filledDictionary.Add("Corner_BL", Corner_BL);
        filledDictionary.Add("Corner_BR", Corner_BR);

        // walls
        filledDictionary.Add("Wall_T", Wall_T);
        filledDictionary.Add("Wall_B", Wall_B);
        filledDictionary.Add("Wall_L", Wall_L);
        filledDictionary.Add("Wall_R", Wall_R);

        // other
        filledDictionary.Add("full_void", full_void);
        filledDictionary.Add("full_wall", full_wall);
        
    }*/
}
