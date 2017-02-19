using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletSpin : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed * Vector3.up * Time.deltaTime);
    }

}
