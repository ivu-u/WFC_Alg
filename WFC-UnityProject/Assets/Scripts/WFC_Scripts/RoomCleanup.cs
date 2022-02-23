using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCleanup : MonoBehaviour
{
    public GameObject managementWFC;
    private NewWFC newWFC;

    private void Awake()
    {
        newWFC = managementWFC.GetComponent<NewWFC>();
    }

    public void roomCleanUp()
    {
        Debug.Log("started cleanup");
        deleteExtraWalls(newWFC.roomMatrix);
    }

    private void deleteExtraWalls(NewNode[,] roomMatrix)
    {
        List<NewNode> wallTiles = findWallTiles(roomMatrix);

        for (int i = 1; i < wallTiles.Count; i++)
        {
            bool isOtherTiles = false;

            if (roomMatrix[wallTiles[i].positionY, wallTiles[i].positionX + 1].label != "groundTile") // check up
            {
                isOtherTiles = true;
            }
            else if(roomMatrix[wallTiles[i].positionY, wallTiles[i].positionX - 1].label != "groundTile") // check down
            {
                isOtherTiles = true;
            }
            else if (roomMatrix[wallTiles[i].positionY + 1, wallTiles[i].positionX].label != "groundTile") // check right
            {
                isOtherTiles = true;
            }
            else if (roomMatrix[wallTiles[i].positionY - 1, wallTiles[i].positionX].label != "groundTile") // check left
            {
                isOtherTiles = true;
            }

            if (!isOtherTiles)
            {
                newWFC.changeMatrix(wallTiles[i]);
            }
        }
    }

    // go through the matrix and find all wall tiles
    private List<NewNode> findWallTiles(NewNode[,] roomMatrix)
    {
        List<NewNode> emptyGroundTiles = new List<NewNode>();

        for (int y = 1; y < roomMatrix.GetLength(0) - 1; y++)   // start at one, end at size - 1 = no edges
        {
            for (int x = 1; x < roomMatrix.GetLength(1) - 1; x++)
            {
                if (roomMatrix[y, x].label == "wallTile")
                {
                    emptyGroundTiles.Add(roomMatrix[y, x]);

                    Debug.Log("found wall tile");
                }
            }
        }

        return emptyGroundTiles;
    }
}
