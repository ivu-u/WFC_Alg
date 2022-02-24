using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public int coins = 0;
    int coinGoal;

    // Start is called before the first frame update
    void Start()
    {
        coinGoal = (PlayerPrefs.GetInt("currentLevel") + 3);
        text.text = "Coins: 0/" + coinGoal;
    }

    public void Add()
    {
        coins++;
        text.text = "Coins: " + coins + "/" + coinGoal;
        if(coins == coinGoal)
        {
            GameObject.FindGameObjectWithTag("Exit").GetComponent<GameExit>().Unlock();
        }
    }
}
