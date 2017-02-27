using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 10.0F;
    public float climbSpeed = 10.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;
    public bool isClimbing;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody rb;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        isClimbing = false;
        rb.isKinematic = false;
    }


    void Update()
    {
        rb.isKinematic = false;
        float h = 0.0f;
        float v = 0.0f;
        if (gameObject.tag.Equals("Player1"))
        {
            h = Input.GetAxisRaw("HorizontalP1");
            v = Input.GetAxisRaw("VerticalP1");
        }
        else
        {
            h = -Input.GetAxisRaw("HorizontalP2");
            v = Input.GetAxisRaw("VerticalP2");
        }

        moveDirection = new Vector3(h, 0, v);
        moveDirection *= speed;
        if (((gameObject.tag.Equals("Player1") && Input.GetButton("JumpP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("JumpP2"))) && CheckGround())
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        if (((gameObject.tag.Equals("Player1") && Input.GetButton("GroundP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("GroundP2"))) && CheckGround())
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection *= speed / 4;
            rb.isKinematic = true;
        }

        if (isClimbing)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection.y = moveDirection.magnitude * climbSpeed;
        }

        transform.Translate(moveDirection * Time.deltaTime);
        /*if (moveDirection != Vector3.zero && moveDirection.y == 0)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(moveDirection),
                Time.deltaTime * speed
            );
        }*/

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = true;
            rb.useGravity = false;
            Debug.Log("Collision enter box\n");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = false;
            rb.useGravity = true;
            Debug.Log("Collision Exit\n");
        }
    }

    private bool CheckGround()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        return Physics.Raycast(transform.position, down, 2.5f);
    }

}
