using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "TileStuff/Tile", order = 1)]
public class ScriptableTile : ScriptableObject
{
    [Header("Basic Info")]
    public string tileName;
    public Sprite tile;

    [Header("Allowed Above")]
    public GameObject[] aboveList;

    [Header("Allowed Below")]
    public GameObject[] aboveBelow;

    [Header("Allowed Left")]
    public GameObject[] leftList;

    [Header("Allowed Right")]
    public GameObject[] rightList;
}
