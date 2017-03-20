using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesFlying : MonoBehaviour {

    private Rigidbody prb;

	public void SendFlying(Vector3 force) {
    
        for (int i = 0; i < transform.childCount; i++)
        {
            prb = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
            prb.AddForce(force);
        }

    }
}
