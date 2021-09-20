using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text keys;
    public Text coins;
    public Text health;
    [SerializeField] private CoinCollection cc;
    [SerializeField] private HurtPlayer hp;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        keys.text = "KEYS: " + cc.currentKeys;
        coins.text = "COINS: " + CoinCollection.currentCoins;
        health.text = "HEALTH: " + HurtPlayer.health;
    }
}
