using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject managementWFC;
    private NewWFC newWFC;
    public GameObject player;
    public GameObject enemy;
    public GameObject coin;

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
        Debug.Log("Current level: " + PlayerPrefs.GetInt("currentLevel"));
        List<GameObject> go = new List<GameObject>();
        go.Add(player);

        int coins = PlayerPrefs.GetInt("currentLevel") + 5;
        int enemies = PlayerPrefs.GetInt("currentLevel") + 5;

        for(int i = 0; i < coins; i++)
        {
            go.Add(coin);
        }
        for (int i = 0; i < enemies; i++)
        {
            go.Add(enemy);
        }

        placeItems(newWFC.roomMatrix, go);
    }

    // place random objects from an array on empty ground tiles 
    public void placeItems(NewNode[,] roomMatrix, List<GameObject> arr)
    {
        List<NewNode> emptyGroundTiles = findEmptyGround(roomMatrix);

        foreach (GameObject g in arr)
        {
            if (g.tag == "Player")  // spawn player at enterance
            {
                NewNode entranceTile = findEntrance(roomMatrix);

                Instantiate(g, new Vector3(entranceTile.positionX, entranceTile.positionY, 0), Quaternion.identity);
            }
            else //spawn other game obejcts randomly
            {
                int rand = RandomGenerators.generateRandNum(emptyGroundTiles);

                // place the game object at the random location
                Instantiate(g, new Vector3(emptyGroundTiles[rand].positionX, emptyGroundTiles[rand].positionY, 0), Quaternion.identity);

                emptyGroundTiles.RemoveAt(rand);
            }

            
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

    public NewNode findEntrance(NewNode[,] roomMatrix)
    {
        NewNode entranceTile = new NewNode(0,0);    // create an empty NewNode to hold data

        for (int y = 0; y < roomMatrix.GetLength(0); y++)
        {
            for (int x = 0; x < roomMatrix.GetLength(1); x++)
            {
                if (roomMatrix[y, x].label == "entranceTile")
                {
                    entranceTile = roomMatrix[y, x];
                    Debug.Log("found entrance");
                }
            }
        }

        return entranceTile;
    }
}
