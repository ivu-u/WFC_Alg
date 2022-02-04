using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TilePainter : MonoBehaviour
{
    //not collapsed - -1
    //wall - 0
    //void - 1
    //ground - 2
    //entrance - 3
    //exit - 4

    public GameObject[] tiles;
    public float paintDelay;
    GameObject f;

    public void spawnTiles(NewNode n)
    {
        switch(n.label)
        {
            case "wallTile":
                f= Instantiate(tiles[0], new Vector3(n.positionY, n.positionX, 0), tiles[0].transform.rotation);
                break;

            case "voidTile":
                f = Instantiate(tiles[1], new Vector3(n.positionY, n.positionX, 0), tiles[1].transform.rotation);
                break;

            case "groundTile":
                f = Instantiate(tiles[2], new Vector3(n.positionY, n.positionX, 0), tiles[2].transform.rotation);
                break;
                
            case "entranceTile":
                f = Instantiate(tiles[3], new Vector3(n.positionY, n.positionX, 0), tiles[3].transform.rotation);
                break;

            case "exitTile":
                f = Instantiate(tiles[4], new Vector3(n.positionY, n.positionX, 0), tiles[4].transform.rotation);
                break;
        }
        f.AddComponent<Identify>();
        f.GetComponent<Identify>().posY = n.positionY;
        f.GetComponent<Identify>().posX = n.positionX;

    }

    public void makeTiles (Queue<NewNode> arr)
    {
        StartCoroutine(spawnTiles(arr));
    }

    public IEnumerator spawnTiles(Queue<NewNode> arr)
    {
        while (arr.Count > 0)
        {
            NewNode n = arr.Dequeue();
            switch (n.label)
            {
                case "wallTile":
                    Instantiate(tiles[0], new Vector3(n.positionY, n.positionX, 0), tiles[0].transform.rotation);
                    break;

                case "voidTile":
                    Instantiate(tiles[1], new Vector3(n.positionY, n.positionX, 0), tiles[1].transform.rotation);
                    break;

                case "groundTile":
                    Instantiate(tiles[2], new Vector3(n.positionY, n.positionX, 0), tiles[2].transform.rotation);
                    break;

                case "entranceTile":
                    Instantiate(tiles[3], new Vector3(n.positionY, n.positionX, 0), tiles[3].transform.rotation);
                    break;

                case "exitTile":
                    Instantiate(tiles[4], new Vector3(n.positionY, n.positionX, 0), tiles[4].transform.rotation);
                    break;
            }
            yield return new WaitForSeconds(paintDelay);
        }
        /*for(int y  = 0; y < arr.GetLength(0); y++)
        {
            for(int x = 0; x < arr.GetLength(1); x++)
            {
                NewNode n = arr[y, x];
                switch (n.label)
                {
                    case "wallTile":
                        Instantiate(tiles[0], new Vector3(n.positionY, n.positionX, 0), tiles[0].transform.rotation);
                        break;

                    case "voidTile":
                        Instantiate(tiles[1], new Vector3(n.positionY, n.positionX, 0), tiles[1].transform.rotation);
                        break;

                    case "groundTile":
                        Instantiate(tiles[2], new Vector3(n.positionY, n.positionX, 0), tiles[2].transform.rotation);
                        break;

                    case "entranceTile":
                        Instantiate(tiles[3], new Vector3(n.positionY, n.positionX, 0), tiles[3].transform.rotation);
                        break;

                    case "exitTile":
                        Instantiate(tiles[4], new Vector3(n.positionY, n.positionX, 0), tiles[4].transform.rotation);
                        break;
                }
                yield return new WaitForSeconds(paintDelay);
            }
        }*/
        
    }
}