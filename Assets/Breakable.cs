using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject pieces;
    public float force;

    private Rigidbody rb;
    private Rigidbody other_rb;

    private Renderer rend;
    private Material mat;


    void OnCollisionEnter(Collision collision){
        rend = GetComponent<Renderer>();
        if (rend != null)
            mat = rend.material;
        rb = gameObject.GetComponent<Rigidbody>();
        other_rb = collision.gameObject.GetComponent<Rigidbody>();
        //Debug.Log("snack collision");
        if (other_rb) {
            if ((rb.velocity.magnitude > force || 
                other_rb.velocity.magnitude > force) &&
                (collision.gameObject.tag == "Player1" ||
                 collision.gameObject.tag == "Player2"))
            {
                Vector3 v = rb.velocity;
                GameObject p = Instantiate(pieces, transform.position, transform.rotation);
                p.transform.localScale = transform.localScale;
                p.GetComponent<SendPiecesFlying>().SendFlying(v, mat);
                Debug.Log("yes");
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}
