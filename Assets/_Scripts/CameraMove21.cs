using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove21 : MonoBehaviour {

    //public GameObject player1;

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    public float RotateSpeed = 4.0f;

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

}
