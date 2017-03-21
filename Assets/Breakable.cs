using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject pieces;
    public float force;

    private Rigidbody rb;
    private Rigidbody other_rb;


    void OnCollisionEnter(Collision collision){
        rb = gameObject.GetComponent<Rigidbody>();
        other_rb = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("snack collision");
        if (rb) {
            if ((rb.velocity.magnitude > force || 
                other_rb.velocity.magnitude > force) &&
                (collision.gameObject.tag == "Player1" ||
                 collision.gameObject.tag == "Player2"))
            {
                Vector3 v = rb.velocity;
                GameObject p = Instantiate(pieces, transform.position, transform.rotation);
                p.transform.localScale = transform.localScale;
                p.GetComponent<SendPiecesFlying>().SendFlying(v);
                gameObject.SetActive(false);
            }
        }
    }

}
