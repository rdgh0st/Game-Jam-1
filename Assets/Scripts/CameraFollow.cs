using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject forward;
    [SerializeField] private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward.transform.position = ball.transform.position + new Vector3(0f, 3.5f, -2f);
        right.transform.position = ball.transform.position + new Vector3(2f, 3.5f, 0f);
        left.transform.position = ball.transform.position + new Vector3(-2f, 3.5f, -0f);
        back.transform.position = ball.transform.position + new Vector3(0f, 3.5f, 2f);
    }
}
