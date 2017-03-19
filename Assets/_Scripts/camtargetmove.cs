using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camtargetmove : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    private Vector3 pos0;
    private Vector3 pos1;

    private Vector3 posNew;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos0 = player1.transform.position;
        pos1 = player2.transform.position;

        //calc mid point
        posNew = (pos0 + pos1) / 2;

        gameObject.transform.position = posNew;

	}
}
