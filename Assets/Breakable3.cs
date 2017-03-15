using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable3 : MonoBehaviour {

    public GameObject pieces;
    private GameObject mainObject;
    public float force;
    // Use this for initialization
    void Start () {
        mainObject = this.transform.parent.gameObject;
        Debug.Log(mainObject);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("snack collision");
        if (rb)
        {
            if (rb.velocity.magnitude > force &&
                (collision.gameObject.tag == "Player1" ||
                 collision.gameObject.tag == "Player2"))
            {
                Instantiate(pieces, transform.position, transform.rotation);
                Destroy(mainObject);
            }
        }
    }
}
