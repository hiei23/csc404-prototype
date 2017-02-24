using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupOutlet : MonoBehaviour {

    public GameObject[] outlets;
    int i;

	// Use this for initialization
	void Start () {
        i = Random.Range(0, outlets.Length);
        outlets[i].SetActive(true);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
