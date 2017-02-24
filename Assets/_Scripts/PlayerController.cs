using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6f;            // The speed that the player will move at

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float h = 0.0f;
        float v = 0.0f;
        float j = 0.0f;

        if (gameObject.tag.Equals("Player1"))
        {
            // Store the input axes.
            h = Input.GetAxisRaw("HorizontalP1");
            v = Input.GetAxisRaw("VerticalP1");
            j = Input.GetAxisRaw("JumpP1");
        }
        else
        {
            h = Input.GetAxisRaw("HorizontalP2");
            v = Input.GetAxisRaw("VerticalP2");
            j = Input.GetAxisRaw("JumpP2"); 
        }

        // Move the player around the scene.
        Move(h, v, j);

    }

    void Move(float h, float v, float j)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, j, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
