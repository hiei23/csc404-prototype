using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
	// Use this for initialization
	void Start () {
        
    }

    public bool isStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(270 - rotation.x);
        float tiltZ = Mathf.Abs(rotation.z);

        return (tiltX < standingThreshold && tiltZ < standingThreshold);
    }

	// Update is called once per frame
	void Update () {
        print(name + isStanding());
    }
}
