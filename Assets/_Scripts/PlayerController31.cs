using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController31 : MonoBehaviour {

    public Text countSnack;
    public Text numBreak;
    public Text winText;

    public Rigidbody rb;
    private int countS;
    private int countB;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        countS = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snack"))
        {
            //other.gameObject.SetActive(false);

            countS = Convert.ToInt32(countSnack.text) + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countSnack.text = countS.ToString();
        /*if (countS >= 5)
        {
            winText.text = "YOU WIN!";
        }*/
        //winText.text = "You've found a snack!";
    }
}
