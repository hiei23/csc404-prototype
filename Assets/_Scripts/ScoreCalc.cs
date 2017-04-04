using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour {

    public Text dollorCost;
    public Text numSnack;

	// Use this for initialization
	void Start () {
        dollorCost.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            int curCost = getCount(dollorCost.text);
            curCost = curCost + other.gameObject.GetComponent<BreakableItem>().getCostOfItem();
            dollorCost.text = SetCountText(curCost);
        }
        //myObject.GetComponent<MyScript>().MyFunction();
        if (other.gameObject.CompareTag("Snack"))
        {
            // you broke and found fish so add up the count
            int curCount = getCount(numSnack.text);
            curCount--;
            numSnack.text = SetCountText(curCount);
        }
    }

    int getCount(string text)
    {
        int counter = int.Parse(text);
        return counter;
    }

    string SetCountText(int counter)
    {
        return counter.ToString();        
    }

}
