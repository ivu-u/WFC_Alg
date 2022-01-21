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
}
