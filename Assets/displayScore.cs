using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayScore : MonoBehaviour {


    public Text numSnack;
    public Text dollorCost;
    
    private int numS;
    private int totalC;

    // Use this for initialization
    void Start () {
        numS = PlayerPrefs.GetInt("numFish");
        totalC = PlayerPrefs.GetInt("totalCost");

        numSnack.text = numS.ToString();
        dollorCost.text = totalC.ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
