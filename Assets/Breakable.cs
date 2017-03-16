﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject pieces;
    public float force;

    private Rigidbody rb;

    void OnCollisionEnter(Collision collision){
        rb = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("snack collision");
        if (rb) {
            if (rb.velocity.magnitude > force &&
                (collision.gameObject.tag == "Player1" ||
                 collision.gameObject.tag == "Player2"))
            {
                Instantiate(pieces, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }
    }

}
