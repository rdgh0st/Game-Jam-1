using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    private float height = 1f;
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
        float targetY = Mathf.Sin(Time.time * speed) * height + xyPos.y;
        gameObject.transform.position = new Vector3(xyPos.x, targetY, xyPos.z);
    }
}
