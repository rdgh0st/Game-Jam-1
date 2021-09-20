using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 3.0f;
    private float jumpHeight = 5.0f;
    private bool spacePressed = false;
    private bool isGrounded = true;

    public string currentCam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentCam = "forward";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            spacePressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (spacePressed)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            spacePressed = false;
        }
        MovePlayer();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void MovePlayer()
    {
        switch (currentCam)
        {
            case "forward":
                rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed, ForceMode.Force);
                break;
            case "back":
                rb.AddForce(new Vector3(-Input.GetAxis("Horizontal"), 0f, -Input.GetAxis("Vertical")) * speed, ForceMode.Force);
                break;
            case "left":
                rb.AddForce(new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal")) * speed, ForceMode.Force);
                break;
            case "right":
                rb.AddForce(new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")) * speed, ForceMode.Force);
                break;
        } 
    }

}
