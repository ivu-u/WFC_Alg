using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTile : MonoBehaviour
{
    [Header("Allowed Above")]
    public GameObject[] aboveList;

    [Header("Allowed Below")]
    public GameObject[] aboveBelow;

    [Header("Allowed Left")]
    public GameObject[] leftList;

    [Header("Allowed Right")]
    public GameObject[] rightList;

    public int entropy;
    public string[] possibilities;
    public int positionX;
    public int positionY;

}
