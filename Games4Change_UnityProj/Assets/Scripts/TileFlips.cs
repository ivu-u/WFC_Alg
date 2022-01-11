using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tile))]
public class TileFlips : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Tile myScript = (Tile)target;
        if(GUILayout.Button("Flip Top and Bottom"))
        {
            myScript.flipTopBottom();
        }

        if (GUILayout.Button("Flip Top and Bottom"))
        {
            myScript.flipSides();
        }
    }
}
