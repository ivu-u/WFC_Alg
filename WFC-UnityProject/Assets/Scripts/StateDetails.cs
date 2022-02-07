using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDetails : MonoBehaviour
{
    //list of all the states we want to hold
    public Dictionary<string, NewTileTemplate> masterTypes = new Dictionary<string, NewTileTemplate>();
    public Dictionary<string, float> masterWeights = new Dictionary<string, float>();

    //GENERATION RULE VARIABLES
    bool entranceGen = false;
    bool exitGen = false;
    public float groundTileWeight;
    public float voidTileWeight;
    public float wallTileWeight;
    public float entranceTileWeight;
    public float exitTileWeight;

    private void Start() {
        //string to weight
        masterWeights.Add("groundTile", groundTileWeight);
        masterWeights.Add("voidTile", voidTileWeight);
        masterWeights.Add("wallTile", wallTileWeight);
        masterWeights.Add("entranceTile", entranceTileWeight);
        masterWeights.Add("exitTile", exitTileWeight);

        //ground tile
        string[] allGround = { "groundTile", "wallTile", "exitTile", "entranceTile" }; ////initialize hashset with an array
        NewTileTemplate groundTile = new NewTileTemplate
        ("groundTile", new HashSet<string>(allGround),
        new HashSet<string>(allGround),
        new HashSet<string>(allGround),
        new HashSet<string>(allGround));
        masterTypes.Add(groundTile.label, groundTile);

        //void tile
        string[] allVoid = {"voidTile", "wallTile"}; //initialize hashset with an array
        NewTileTemplate voidTile = new NewTileTemplate
        ("voidTile", new HashSet<string>(allVoid), 
        new HashSet<string>(allVoid), 
        new HashSet<string>(allVoid), 
        new HashSet<string>(allVoid));
        masterTypes.Add(voidTile.label, voidTile);

        //wall tile
        string[] allWall = { "voidTile", "wallTile", "groundTile", "entranceTile", "exitTile"};
        NewTileTemplate wallTile = new NewTileTemplate
        ("wallTile", new HashSet<string>(allWall), 
        new HashSet<string>(allWall), 
        new HashSet<string>(allWall), 
        new HashSet<string>(allWall));
        masterTypes.Add(wallTile.label, wallTile);

        //entrance tile
        string[] allEntrance = {"groundTile", "wallTile"}; //initialize hashset with an array
        NewTileTemplate entranceTile = new NewTileTemplate
        ("entranceTile", new HashSet<string>(allEntrance), 
        new HashSet<string>(allEntrance), 
        new HashSet<string>(allEntrance), 
        new HashSet<string>(allEntrance));
        masterTypes.Add(entranceTile.label, entranceTile);

        //exit tile
        string[] allExit = { "groundTile", "wallTile" };
        NewTileTemplate exitTile = new NewTileTemplate
        ("exitTile", new HashSet<string>(allExit), 
        new HashSet<string>(allExit), 
        new HashSet<string>(allExit), 
        new HashSet<string>(allExit));
        masterTypes.Add(exitTile.label, exitTile);
    }
}