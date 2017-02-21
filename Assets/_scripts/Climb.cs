using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    private float speed = 4.0f;
    // Use this for initialization
    private Rigidbody rb;
    private bool isClimbing;

    void Start()
    {
        isClimbing = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }*/

        if (Input.GetKey(KeyCode.Space) && isClimbing)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            Debug.Log("MOVING UP\n");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Curtain")
        {
            rb.isKinematic = true;
            isClimbing = !isClimbing;
            Debug.Log("Collision enter box\n");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Curtain")
        {
            rb.isKinematic = false;
            isClimbing = !isClimbing;
            Debug.Log("Collision Exit\n");
        }
    }
}
