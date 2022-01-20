using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTile : MonoBehaviour
{
    // what is allowed on each side of the tile (since it is initially filled with all possibiilites all
    // tiles are initially posible (they will get slowly crossed out as possibilities are removed
    public HashSet<string> allowedAbove;
    public HashSet<string> allowedBelow;
    public HashSet<string> allowedLeft;
    public HashSet<string> allowedRight;

    public HashSet<string> possibilities;  // what can be placed inside of THIS tile - this is determined by what is allowed by the side rules of other tiles
                                    // what is allowed to the sides of this tile - this is changed by what can be placed inside of this tile

    // entrpy can be found with possibilities.count
    
    public int positionX;
    public int positionY;
}
