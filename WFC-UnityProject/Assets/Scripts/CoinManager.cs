using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Coins: 0/3";
    }

    public void Add()
    {
        coins++;
        text.text = "Coins: " + coins + "/3";
        if(coins == 3)
        {
            GameObject.FindGameObjectWithTag("Exit").GetComponent<GameExit>().Unlock();
        }
    }
}
