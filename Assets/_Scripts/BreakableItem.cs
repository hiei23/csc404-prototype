using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour {

    public int minCost = 0;
    public int maxCost = 0;
    private int cost;

	// Use this for initialization
	void Start () {

		// generate cost of this item/furniture
        if(minCost != 0 && maxCost != 0)
        {
            cost = Random.Range(minCost, maxCost);
        }else
        {// if min cost and max cost not specified
            cost = Random.Range(99, 999);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getCostOfItem()
    {
        return cost;
    }


}
