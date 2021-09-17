using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera back;
    [SerializeField] private Camera left;
    [SerializeField] private Camera right;
    [SerializeField] private Camera forward;
    private bool leftActive;
    private bool rightActive;
    private bool forwardActive;
    private bool backActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardActive = forward.enabled;
        backActive = back.enabled;
        leftActive = left.enabled;
        rightActive = right.enabled;
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchRight();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchLeft();
        }
    }

    private void SwitchLeft()
    {
        if (backActive)
        {
            right.enabled = true;
            back.enabled = false;
            Debug.Log("camera position is right");
        }
        if (rightActive)
        {
            forward.enabled = true;
            right.enabled = false;
            Debug.Log("camera position is forward");
        }
        if (leftActive)
        {
            back.enabled = true;
            left.enabled = false;
            Debug.Log("camera position is back");
        }
        if (forwardActive)
        {
            left.enabled = true;
            forward.enabled = false;
            Debug.Log("camera position is left");
        }
    }

    private void SwitchRight()
    {
        if (backActive)
        {
            left.enabled = true;
            back.enabled = false;
            Debug.Log("camera position is left");
        }
        if (rightActive)
        {
            back.enabled = true;
            right.enabled = false;
            Debug.Log("camera position is back");
        }
        if (leftActive)
        {
            forward.enabled = true;
            left.enabled = false;
            Debug.Log("camera position is forward");
        }
        if (forwardActive)
        {
            right.enabled = true;
            forward.enabled = false;
            Debug.Log("camera position is right");
        }
    }

}