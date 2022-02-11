using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject coin;

    public GameObject managementWFC;
    private NewWFC newWFC;

    private void Awake()
    {
        newWFC = managementWFC.GetComponent<NewWFC>();
    }

    /*void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spawnTest();
        }
    }*/

    public void spawnTest()
    {
        GameObject[] go = {player, coin, coin, enemy};

        placeItems(newWFC.roomMatrix, go);
    }

    // place random objects from an array on empty ground tiles 
    public void placeItems(NewNode[,] roomMatrix, GameObject[] arr)
    {
        List<NewNode> emptyGroundTiles = findEmptyGround(roomMatrix);

        foreach (GameObject g in arr)
        {
            int rand = RandomGenerators.generateRandNum(emptyGroundTiles);

            // place the game object at the random location
            Instantiate(g, new Vector3(emptyGroundTiles[rand].positionX, emptyGroundTiles[rand].positionY, 0), Quaternion.identity);

            emptyGroundTiles.RemoveAt(rand);
        }
    }

    // loop through the entire room and put all ground tiles in a list
   public List<NewNode> findEmptyGround(NewNode[,] roomMatrix)
    {
        List<NewNode> emptyGroundTiles = new List<NewNode>();

        for (int y = 0; y < roomMatrix.GetLength(0); y++)
        {
            for (int x = 0; x < roomMatrix.GetLength(1); x++)
            {
                if (roomMatrix[y,x].label == "groundTile")
                {
                    emptyGroundTiles.Add(roomMatrix[y, x]);
                }
            }
        }

        return emptyGroundTiles;
    }
}
