using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimations : MonoBehaviour {

    //public int curr_state = 0;

    //private enum aState { idle, walk, flail };
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
            animator.SetInteger("State", 0);
        if (Input.GetKeyDown("s"))
            animator.SetInteger("State", 1);
        if (Input.GetKeyDown("d"))
            animator.SetInteger("State", 2);
    }
}
