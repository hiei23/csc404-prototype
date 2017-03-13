using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 40f;
    private float sensitivityY = 1.0f;

    // Use this for initialization
    void Start () {
        camTransform = transform;
        cam = Camera.main;
	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
    // Update is called once per frame
    void Update () {
        currentY = Input.GetAxis("HorizontalP1");
        currentX = Input.GetAxis("VerticalP1");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MAX, Y_ANGLE_MIN);
    }
}
