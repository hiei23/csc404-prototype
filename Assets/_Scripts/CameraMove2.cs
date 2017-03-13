using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour {

    //public GameObject player1;

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    //public float xSpeed = 250.0F;
    //public float ySpeed = 120.0F;

    private Transform cameraTransform;
    //private float x;
    //private float y;


    //private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        //offset = transform.position - player1.transform.position;
        cameraTransform = transform;
    }

    void LateUpdate()
    {
        //transform.position = player1.transform.position + offset;
        cameraTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        cameraTransform.LookAt(target);
    }

    /*
    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        { //right button
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -walkDistance) + target.position;

            cameraTransform.rotation = rotation;
            cameraTransform.position = position;


        }
        //transform.position = player1.transform.position + offset;
        //cameraTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        //cameraTransform.LookAt(target);

    }
    */
}
