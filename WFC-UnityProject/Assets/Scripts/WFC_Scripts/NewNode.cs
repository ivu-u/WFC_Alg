using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNode : MonoBehaviour
{
    // what is allowed on each side of the node (since it is initially filled with all possibiilites all
    // all states are initially posible (they will get slowly crossed out as possibilities are removed

    //label
    public string label;
    StateDetails masterList = GameObject.FindGameObjectWithTag("Dictionary").GetComponent<StateDetails>();

    public bool isCollapsed = false;

    public HashSet<string> possibilities;  // what can be placed inside of THIS node - this is determined by what is allowed by the side rules of other tiles

    public HashSet<string> allowedAboveThisNode;
    public HashSet<string> allowedBelowThisNode;
    public HashSet<string> allowedLeftThisNode;
    public HashSet<string> allowedRightThisNode;   // what is allowed to the sides of this node - this is changed by what can be placed inside of this tile - this is what other tiles check

    // entrpy can be found with possibilities.count

    public int positionX;
    public int positionY;

    public NewNode(int y, int x)
    {
        label = null;
        string[] all = { "groundTile", "voidTile", "wallTile", "exitTile", "entraceTile" };
        possibilities = new HashSet<string>(all);
        allowedAboveThisNode = new HashSet<string>(all);
        allowedBelowThisNode = new HashSet<string>(all);
        allowedLeftThisNode = new HashSet<string>(all);
        allowedRightThisNode = new HashSet<string>(all);

        // set position here
        positionX = x;
        positionY = y;
    }

    public void updateAdjacency() 
    {
        allowedAboveThisNode = new HashSet<string>();
        foreach(string key in possibilities) {
            NewTileTemplate tile;
            masterList.masterTypes.TryGetValue(key, out tile);
            allowedAboveThisNode.UnionWith(tile.allowedAbove);
        }

        allowedBelowThisNode = new HashSet<string>();
        foreach(string key in possibilities) {
            NewTileTemplate tile;
            masterList.masterTypes.TryGetValue(key, out tile);
            allowedBelowThisNode.UnionWith(tile.allowedBelow);
        }

        allowedLeftThisNode = new HashSet<string>();
        foreach(string key in possibilities) {
            NewTileTemplate tile;
            masterList.masterTypes.TryGetValue(key, out tile);
            allowedLeftThisNode.UnionWith(tile.allowedLeft);
        }

        allowedRightThisNode = new HashSet<string>();
        foreach(string key in possibilities) {
            NewTileTemplate tile;
            masterList.masterTypes.TryGetValue(key, out tile);
            allowedRightThisNode.UnionWith(tile.allowedRight);
        }
    }
}
