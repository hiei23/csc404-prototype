using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerDisplay;
    public float remainingTime = 120.0f;

	// Use this for initialization
	void Start () {
        timerDisplay.text = remainingTime.ToString("F1");
	}
	
	// Update is called once per frame
	void Update () {
        remainingTime -= Time.deltaTime;
        timerDisplay.text = remainingTime.ToString("F1");

        if (remainingTime <= 0.0f)
        {
            timeEnd();
        }
	}

    void timeEnd()
    {

    }
}
