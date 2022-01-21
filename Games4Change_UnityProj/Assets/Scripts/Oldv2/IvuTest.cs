using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvuTest : MonoBehaviour
{
    RoomWFC roomWFC;

    private void Start()
    {
        roomWFC = new RoomWFC();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            testRandom();
        }
    }

    private void testRandom()
    {
        int num = roomWFC.generateRandom();
        Debug.Log(num);
    }
}
