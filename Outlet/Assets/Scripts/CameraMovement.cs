using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Camera mainCamera;
    public GameObject player1;
    public GameObject player2;

    private Vector3 velocity = Vector3.zero;

    // Moves the camera
    void FixedUpdate()
    {
        Vector3 average = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2 + 10.0f, 23.0f, (player1.transform.position.z + player2.transform.position.z) / 2 - 20.0f);
        mainCamera.transform.localPosition = Vector3.SmoothDamp(mainCamera.transform.localPosition, average, ref velocity, 0.2f);
    }
}

