using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTileTemplate : MonoBehaviour
{
    //template tile
    public string label;
    public HashSet<string> allowedAbove;
    public HashSet<string> allowedBelow;
    public HashSet<string> allowedLeft;
    public HashSet<string> allowedRight;

    public NewTileTemplate (string l, HashSet<string> above, HashSet<string> below, HashSet<string> left, HashSet<string> right) 
    {
        label = l;
        allowedAbove = above;
        allowedBelow = below;
        allowedRight = right;
        allowedLeft = left;
    }
}
