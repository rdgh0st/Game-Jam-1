using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    public float health = 3.0f;
    private Vector3 startingPos;
    public bool setCheckpoint;
    private Rigidbody rb;
    private CameraControl cc;
    [SerializeField] private AudioSource victory;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CameraControl>();
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
        if ((collision.gameObject.name.Contains("saw")))
        {
            health--;
        }
        if (collision.gameObject.name.Contains("button"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.name.Contains("finish"))
        {
            cc.forward.enabled = true;
            cc.back.enabled = false;
            cc.left.enabled = false;
            cc.right.enabled = false;
            victory.Play();
            Destroy(gameObject);
        }
    }

}
