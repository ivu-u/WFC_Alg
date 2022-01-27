using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNode : MonoBehaviour
{
    // what is allowed on each side of the node (since it is initially filled with all possibiilites all
    // all states are initially posible (they will get slowly crossed out as possibilities are removed

    //label
    public string label;
    StateDetails masterList = GameObject.FindObjectsWithTag("Dictionary");

    bool collapsed = false;

    public HashSet<string> possibilities;  // what can be placed inside of THIS node - this is determined by what is allowed by the side rules of other tiles

    public HashSet<string> allowedAbove;
    public HashSet<string> allowedBelow;
    public HashSet<string> allowedLeft;
    public HashSet<string> allowedRight;   // what is allowed to the sides of this node - this is changed by what can be placed inside of this tile - this is what other tiles check

    // entrpy can be found with possibilities.count

    public int positionX;
    public int positionY;

    public NewNode(int x, int y)
    {
        label = null;
        possibilities = new HashSet<string>("groundTile", "voidTile", "wallTile", "exitTile", "entraceTile");
        allowedAbove = new HashSet<string>("groundTile", "voidTile", "wallTile", "exitTile", "entraceTile");
        allowedBelow = new HashSet<string>("groundTile", "voidTile", "wallTile", "exitTile", "entraceTile");
        allowedLeft = new HashSet<string>("groundTile", "voidTile", "wallTile", "exitTile", "entraceTile");
        allowedRight = new HashSet<string>("groundTile", "voidTile", "wallTile", "exitTile", "entraceTile");
        positionX = x;
        positionY = y;
    }

    public void updateAdjacency() 
    {
        allowedAbove = allowedAbove.Clear();
        foreach(string item in possibilities) {
            allowedAbove = allowedAbove.UnionWith(masterList.masterTypes.TryGetValue(item).allowedAbove);
        }

        allowedBelow = allowedBelow.Clear();
        foreach(string item in possibilities) {
            allowedBelow = allowedBelow.UnionWith(masterList.masterTypes.TryGetValue(item).allowedBelow);
        }

        allowedLeft = allowedLeft.Clear();
        foreach(string item in possibilities) {
            allowedLeft = allowedLeft.UnionWith(masterList.masterTypes.TryGetValue(item).allowedLeft);
        }

        allowedRight = allowedRight.Clear();
        foreach(string item in possibilities) {
            allowedRight = allowedRight.UnionWith(masterList.masterTypes.TryGetValue(item).allowedRight);
        }
    }
}
