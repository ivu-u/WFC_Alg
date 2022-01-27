using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDetails : MonoBehaviour
{
    //list of all the states we want to hold
    public Dictionary<string, NewTileTemplate> masterTypes = new Dictionary<string, NewTileTemplate>();

    private void Start() {
        //ground tile
        NewTileTemplate groundTile = NewTileTemplate
        ("groundTile", new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"));
        masterTypes.Add(groundTile.label, groundTile);

        //void tile
        NewTileTemplate voidTile = NewTileTemplate
        ("voidTile", new HashSet<string>("voidTile", "wallTile"), 
        new HashSet<string>("voidTile", "wallTile"), 
        new HashSet<string>("voidTile", "wallTile"), 
        new HashSet<string>("voidTile", "wallTile"));
        masterTypes.Add(voidTile.label, voidTile);

        //wall tile
        NewTileTemplate wallTile = NewTileTemplate
        ("wallTile", new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"), 
        new HashSet<string>("groundTile", "wallTile", "exitTile", "entranceTile", "voidTile"));
        masterTypes.Add(wallTile.label, wallTile);

        //entrance tile
        NewTileTemplate entranceTile = NewTileTemplate
        ("entranceTile", new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"));
        masterTypes.Add(entranceTile.label, entranceTile);

        //exit tile
        NewTileTemplate exitTile = NewTileTemplate
        ("exitTile", new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"), 
        new HashSet<string>("groundTile", "wallTile"));
        masterTypes.Add(exitTile.label, exitTile);
    }
}