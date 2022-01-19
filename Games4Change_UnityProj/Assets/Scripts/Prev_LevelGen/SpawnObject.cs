using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // pass in a list of gameobjects
    public GameObject[] objects;

    private void Start()
    {
        // used to set random tiles
        int rand = Random.Range(0, objects.Length);

        // array with an inex rand, spawnpoint position, no rotation
        GameObject instance = (GameObject) Instantiate(objects[rand], transform.position, Quaternion.identity);
        instance.transform.parent = transform;  // set as a child to what spawned it
    }
}
