using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;
    // Use this for initialization
    private Vector3 offset;
	void Start () {
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //in front of head pin
        if (ball.transform.position.z <= 2415f)
        {
            transform.position = ball.transform.position + offset;
        }
	}
}
