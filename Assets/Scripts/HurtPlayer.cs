using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public float health = 3.0f;
    private Vector3 startingPos;
    public bool setCheckpoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setCheckpoint)
        {
            startingPos = gameObject.transform.position;
            setCheckpoint = false;
        }
        if (health <= 0)
        {
            gameObject.transform.position = startingPos;
            health = 3.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("spikes"))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            health--;
        }
    }

}
