using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomGenerators
{
    // generate a random number from a list
    public static int generateRandNum(List<NewNode> list)
    {
        int randNum = Random.Range(0, list.Count);

        return randNum;
    }

    // generate a random even number from a list
    public static int generateRandEvenNum(List<int> list)
    {
        int randNum = Random.Range(0, list.Count / 2);
        randNum = randNum * 2;

        return randNum;
    }
}
