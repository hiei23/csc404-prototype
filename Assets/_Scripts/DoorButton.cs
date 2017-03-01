using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInParent<Animator>();
    }
	
	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            animator.SetTrigger("Open");

        }
    }
}
