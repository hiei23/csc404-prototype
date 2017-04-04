using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPiecesFlying : MonoBehaviour {

    private Rigidbody prb;
    private Renderer rend;

	public void SendFlying(Vector3 force, Material mat) {
    
        for (int i = 0; i < transform.childCount; i++)
        {
            prb = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
            rend = transform.GetChild(i).gameObject.GetComponent<Renderer>();
            if (prb != null)
                prb.AddForce(force);
            if (rend && mat)
                rend.material = mat;
        }

    }
}
