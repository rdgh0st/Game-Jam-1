using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public float currentCoins = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("detected trigger");
        if (other.name.Contains("coinGold"))
        {
            currentCoins++;
            Destroy(other.gameObject);
            Debug.Log("Coin Counter: " + currentCoins);
        }
    }

}
