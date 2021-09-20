using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private AudioSource snd_GetCoin;
    [SerializeField] private AudioSource snd_GetKey;
    [SerializeField] private AudioSource snd_Health;
    public static float currentCoins = 0.0f;
    public float currentKeys = 0.0f;
    private HurtPlayer hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HurtPlayer>();
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
            snd_GetCoin.Play();
            Debug.Log("Coin Counter: " + currentCoins);
        } else if (other.name.Contains("key")) {
            currentKeys++;
            Destroy(other.gameObject);
            snd_GetKey.Play();
            Debug.Log("Key Counter: " + currentKeys);
        } 
        if (other.name.Contains("door") && currentKeys >= 1)
        {
            currentKeys--;
            Vector3 pos = other.gameObject.transform.position;
            Quaternion rot = other.gameObject.transform.rotation;
            Destroy(other.gameObject);
            GameObject newdoor = Object.Instantiate(doorOpen);
            newdoor.gameObject.transform.rotation = rot;
            newdoor.gameObject.transform.position = pos;
            Debug.Log("made a door at" + pos);
        } else if (other.name.Contains("heart"))
        {
            HurtPlayer.health++;
            Destroy(other.gameObject);
            snd_Health.Play();
            Debug.Log("Health: " + HurtPlayer.health);
        }
    }

}
