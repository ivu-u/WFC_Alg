using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    GameObject collectionManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CollectCoin();
        }
    }

    void CollectCoin ()
    {
        collectionManager.GetComponent<CoinManager>().Add();
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        collectionManager = GameObject.FindGameObjectWithTag("EventSystem");
    }
}
