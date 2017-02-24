using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public int lastStadingCount = -1;
    public Text stadingDisplay;

    private float lastUpdate;
    private Ball ball;
    private bool ballEnteredBox = false; 
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        //print(countStanding().ToString());
        if (ballEnteredBox)
        {
            checkStanding();
        }
        stadingDisplay.text = countStanding().ToString();
    }

    void checkStanding()
    {
        int currentStadning = countStanding();

        if (currentStadning!= lastStadingCount)
        {
            lastUpdate = Time.time;
            lastStadingCount = currentStadning;
            return;
        }

        float settleTime = 1f;
        print(Time.time - lastUpdate);
        if ((Time.time - lastUpdate) > settleTime || ball.transform.position.y < 0)
        {
            pinsHaveSettle();
        }
    }

    void pinsHaveSettle()
    {
        ball.Reset();
        lastStadingCount = -1;
        ballEnteredBox = false;
        stadingDisplay.color = Color.green;
    }
    int countStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponent<Pin>())
        {
            DestroyObject(thingLeft);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;

        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            stadingDisplay.color = Color.red;
        }
    }
}
