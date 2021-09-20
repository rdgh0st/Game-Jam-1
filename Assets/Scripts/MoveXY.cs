using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXY : MonoBehaviour
{
    private float length = 1f;
    private float speed = 3.0f;
    private Vector3 xyPos;
    // Start is called before the first frame update
    void Start()
    {
        xyPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = Mathf.Sin(Time.time * speed) * length + xyPos.y;
        gameObject.transform.position = new Vector3(xyPos.x + targetX, xyPos.y, xyPos.z);
        transform.Rotate(Vector3.forward * 240 * Time.deltaTime);
    }
}
