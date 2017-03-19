using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{

    //public GameObject player1;

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    private Transform cameraTransform;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        cameraTransform = transform;
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        /* angle #1 - cats are close to the bottom of game play screen */
        //transform.position = target.transform.position + offset;

        /* angle #2 - cats are more center of the game play screen */
        cameraTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        cameraTransform.LookAt(target);

    }

}
