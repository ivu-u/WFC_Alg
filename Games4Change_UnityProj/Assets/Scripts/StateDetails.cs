using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDetails : MonoBehaviour
{
    //list of all the states we want to hold
    public Dictionary<string, NewTileTemplate> masterTypes = new Dictionary<string, NewTileTemplate>();

    private void Start() {
        //ground tile
        string[] all = { "groundTile", "wallTile", "exitTile", "entranceTile", "voidTile" }; ////initialize hashset with an array
        NewTileTemplate groundTile = new NewTileTemplate
        ("groundTile", new HashSet<string>(all),
        new HashSet<string>(all),
        new HashSet<string>(all),
        new HashSet<string>(all));
        masterTypes.Add(groundTile.label, groundTile);

        //void tile
        string[] voidStart = {"voidTile", "wallTile"}; //initialize hashset with an array
        NewTileTemplate voidTile = new NewTileTemplate
        ("voidTile", new HashSet<string>(voidStart), 
        new HashSet<string>(voidStart), 
        new HashSet<string>(voidStart), 
        new HashSet<string>(voidStart));
        masterTypes.Add(voidTile.label, voidTile);

        //wall tile
        NewTileTemplate wallTile = new NewTileTemplate
        ("wallTile", new HashSet<string>(all), 
        new HashSet<string>(all), 
        new HashSet<string>(all), 
        new HashSet<string>(all));
        masterTypes.Add(wallTile.label, wallTile);

        //entrance tile
        string[] entranceStart = {"groundTile", "wallTile"}; //initialize hashset with an array
        NewTileTemplate entranceTile = new NewTileTemplate
        ("entranceTile", new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart));
        masterTypes.Add(entranceTile.label, entranceTile);

        //exit tile
        NewTileTemplate exitTile = new NewTileTemplate
        ("exitTile", new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart), 
        new HashSet<string>(entranceStart));
        masterTypes.Add(exitTile.label, exitTile);
    }
}