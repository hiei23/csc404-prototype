using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerDisplay;
    public float remainingTime = 120.0f;

    public float tutorialtime = 8.0f;

    private bool isTutorial = true;

    public RawImage tutorial;
    public GameObject UI_timer;
    public GameObject UI_score;
    public GameObject UI_clock;

    public Text dollorCost;
    public Text numSnack;

    private bool endTimer;
    private float displayTime = 3.0f;

    // Use this for initialization
    void Start () {
        //
        isTutorial = true;
        tutorial.enabled = true;

        UI_timer.SetActive(false);
        UI_score.SetActive(false);

        UI_clock.SetActive(false);
        endTimer = false;
    }
	
	// Update is called once per frame
	void Update () {

        // display tutorial image for some time
        if (isTutorial)
        {
            tutorialtime -= Time.deltaTime;

            if (tutorialtime <= 0.0f)
            {
                isTutorial = false;
                tutorial.enabled = false;
                startTimer();
            }
        }else
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0.0f)
            {
                timeEnd();
            }else
            {
                timerDisplay.text = remainingTime.ToString("F1");
            }
        }

        // after time is up
        if (endTimer)
        {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0.0f)
            {
                toEndScene();
            }
        }



        
	}

    void startTimer()
    {
        timerDisplay.text = remainingTime.ToString("F1");
        remainingTime = 120.0f;
        UI_timer.SetActive(true);
        UI_score.SetActive(true);
    }

    void timeEnd()
    {
        PlayerPrefs.SetInt("numFish", getCount(numSnack.text));
        PlayerPrefs.SetInt("totalCost", getCount(dollorCost.text));
        UI_clock.SetActive(true);
        endTimer = true;        
    }

    int getCount(string text)
    {
        int counter = int.Parse(text);
        return counter;
    }

    void toEndScene()
    {
        SceneManager.LoadScene("end_scene2", LoadSceneMode.Single);
    }
}
