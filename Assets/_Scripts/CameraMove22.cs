using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove22 : MonoBehaviour {

    //public GameObject player1;

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    public float RotateSpeed = 30f;

    //public float xSpeed = 250.0F;
    //public float ySpeed = 120.0F;

    private Transform cameraTransform;
    //private float x;
    //private float y;

    private Vector3 offsetX;
    private Vector3 offsetY;


    // Use this for initialization
    void Start()
    {
        offsetX = new Vector3(0, height,-walkDistance);
        offsetY = new Vector3(0, 0, -walkDistance);
        cameraTransform = transform;
    }

    void LateUpdate()
    {
        

        offsetX = Quaternion.AngleAxis(Input.GetAxis("Axis4P1") * RotateSpeed * Time.deltaTime, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Axis5P1") * RotateSpeed * Time.deltaTime, Vector3.right) * offsetY;

        cameraTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance) + offsetX + offsetY;
        cameraTransform.LookAt(target);

    }

}
