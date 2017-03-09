using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject pieces;

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
            Instantiate(pieces, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

}
