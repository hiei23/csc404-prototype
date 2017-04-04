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

    public int minCost = 0;
    public int maxCost = 0;
    private int cost;

    // Use this for initialization
    void Start()
    {

        // generate cost of this item/furniture
        if (minCost != 0 && maxCost != 0)
        {
            cost = Random.Range(minCost, maxCost);
        }
        else
        {// if min cost and max cost not specified
            cost = Random.Range(99, 999);
        }

    }

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
                collision.gameObject.GetComponent<ScoreCalc>().addCost(cost);
                //Debug.Log("yes");
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}
