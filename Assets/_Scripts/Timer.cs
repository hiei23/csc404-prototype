using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerDisplay;
    public float remainingTime;

    public float tutorialtime = 8.0f;

    private bool isTutorial = true;

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
        UI_clock.SetActive(false);
        endTimer = false;
    }
	
	// Update is called once per frame
	void Update () {

        // display tutorial image for some time
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0.0f)
        {
            timeEnd();
        }
        if (remainingTime > 0.0f)
        {
            timerDisplay.text = remainingTime.ToString("F1");
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
