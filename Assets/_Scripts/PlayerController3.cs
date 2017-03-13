﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 10.0F;
    public float climbSpeed = 10.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;
    public float maxSpeed = 20.0F;
    public bool isClimbing;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody rb;

    public Text countSnack;
    private int total_snacks;
    private int MAX_SNACKS = 16;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        isClimbing = false;
        rb.isKinematic = false;
        total_snacks = 0;
    }


    void Update()
    {
        rb.isKinematic = false;
        float h = 0.0f;
        float v = 0.0f;
        float d = 0.0f;
        Vector3 delta = new Vector3(0, 0, 0);
        GameObject other;
        if (gameObject.tag.Equals("Player1"))
        {
            h = Input.GetAxisRaw("HorizontalP1");
            v = Input.GetAxisRaw("VerticalP1");
            other = GameObject.FindWithTag("Player2");
        }
        else
        {
            h = -Input.GetAxisRaw("HorizontalP2");
            v = Input.GetAxisRaw("VerticalP2");
            other = GameObject.FindWithTag("Player1");
        }

        moveDirection = new Vector3(h, d, v);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection *= speed;
        if (((gameObject.tag.Equals("Player1") && Input.GetButton("JumpP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("JumpP2"))) && CheckGround())
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        if (((gameObject.tag.Equals("Player1") && Input.GetButton("ReturnP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("ReturnP2"))))
        {
            delta = other.transform.position - transform.position;
            h = delta.x == 0 ? 0 : (delta.x > 0 ? 1 : -1);
            v = delta.y == 0 ? 0 : (delta.y > 0 ? 1 : -1);
            d = delta.z == 0 ? 0 : (delta.z > 0 ? 1 : -1);
            moveDirection = new Vector3(h, d, v);
            moveDirection *= speed;
        }
        if (isClimbing)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection.y = moveDirection.magnitude * climbSpeed;
        }


        if (((gameObject.tag.Equals("Player1") && Input.GetButton("GroundP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("GroundP2"))) && CheckGround())
        {
            moveDirection = new Vector3(h, d, v);
            moveDirection *= speed / 4;
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0;
            rb.isKinematic = true;
            transform.Translate(moveDirection * Time.deltaTime);
        }
        else
        {
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            else
            {

                rb.AddForce(moveDirection * Time.deltaTime * 100);
            }
        }
        /*
        if (moveDirection != Vector3.zero && moveDirection.y == 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            float rotationSpeed = 100.0f;
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                 
            //Apply the rotation
            rb.MoveRotation(newRotation);
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


        if (other.gameObject.CompareTag("Snack"))
        {
            //other.gameObject.SetActive(false);
            Debug.Log("Snack!\n");
            total_snacks++;
            SetCountText();
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

    void SetCountText()
    {
        int remaining = MAX_SNACKS - total_snacks;
        string counter_label = String.Format("Total Number of Snacks left: {0}" , remaining);
        countSnack.text = counter_label;
    }

}
