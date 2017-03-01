using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour {

    public Camera cam1;
    private Animator cam1Ani;
    public GameObject stage1set;
    public GameObject stage2wall4;
    public GameObject player1;
    public GameObject player2;
    
    bool lev1stage1clear;

    private Vector3 stage1initialposP1;
    private Vector3 stage1initialposP2;
    private Vector3 stage2initialposP1;
    private Vector3 stage2initialposP2;

    //private Animator animator;

    // Use this for initialization
    void Start () {
        lev1stage1clear = false;
        //animator = gameObject.GetComponentInParent<Animator>();
        cam1Ani = cam1.GetComponent<Animator>();
        //stage1initialposP1 = player1.transform.position;
        stage2initialposP1 = new Vector3(128, 3, 129);
        stage2initialposP2 = new Vector3(148, 3, 128);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {   if(lev1stage1clear == false)
        {
            Debug.Log("Collision Detected");
            if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
            {
                Debug.Log("TagIdentified");
                lev1stage1clear = true;
                // move camera                
                cam1Ani.SetTrigger("Move");

                // light on off? - later
                //move both players to stage 2
                player1.transform.position = stage2initialposP1;
                player2.transform.position = stage2initialposP2;
                // turn back wall2.4 on (invisible block)
                stage2wall4.SetActive(true);
                // turn off stage 1
                stage1set.SetActive(false);

            }
        }
        
    }
}

