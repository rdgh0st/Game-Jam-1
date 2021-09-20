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
    [SerializeField] private AudioSource snd_Rolling, snd_Jump, snd_Land, mus_GameMusic;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentCam = "forward";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacePressed = true;
            }
            snd_Rolling.pitch = rb.velocity.magnitude / 3f;
        }
        else
        {
            snd_Rolling.pitch = 0;
        }
        if (!snd_Land.isPlaying)
        {
            snd_Land.volume = rb.velocity.magnitude / 4f;
            snd_Land.pitch = rb.velocity.magnitude / 4f;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            mus_GameMusic.volume = mus_GameMusic.volume == 0 ? 0.5f : 0f;
        }
    }

    private void FixedUpdate()
    {
        if (spacePressed)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            spacePressed = false;
            snd_Jump.Play();
        }
        MovePlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!snd_Land.isPlaying)
            snd_Land.Play();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
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
