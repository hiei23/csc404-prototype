using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesFlying : MonoBehaviour {

    private Rigidbody prb;

	public void SendFlying(Vector3 force) {

        //m_gameObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            //Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            //transform.GetChild(i).gameObject;
            //m_gameObjects[i] = transform.GetChild(i).gameObject;
        }

    }
}
