using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour {

    public int minCost;
    public int maxCost;

    public bool isfish = false;

    private int cost;
    

    public float fishProb;

	// Use this for initialization
	void Start () {

		// generate cost of this item/furniture
        if(minCost != null && maxCost != null)
        {
            cost = Random.Range(minCost, maxCost);
        }else
        {// if min cost and max cost not specified
            cost = Random.Range(99, 999);
        }

        // generate fish inside this item (may not contain one



	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getCostOfItem()
    {
        return cost;
    }

    public bool isFishHere()
    {
        return isfish;
    }
}
