using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenFloor : MonoBehaviour {


    //public GameObject rm3_wall_south;
    public GameObject rm1_wall_north;
    //public Renderer wall;

    bool isInKitchen;


    // Use this for initialization
    void Start () {
        isInKitchen = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Kitchen!!");
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            Debug.Log("there should be no wall");
            rm1_wall_north.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("no one in Kitchen!!");
        rm1_wall_north.SetActive(true);

    }
}
