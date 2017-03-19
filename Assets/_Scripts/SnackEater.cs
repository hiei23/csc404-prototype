using System;
using UnityEngine;
using UnityEngine.UI;

public class SnackEater : MonoBehaviour {

    public Text countSnack;

    public Text numSnack;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    /*
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Snack"))
        {
            //other.gameObject.SetActive(false);
            Debug.Log("Snack!\n");
            int current_counter = getCounter(countSnack.text);            
            current_counter--;
            SetCountText(current_counter);

        }
    }*/

    int getCounter(string text)
    {
        string[] separator = new string[] { ":" };
        string[] parts = text.Split(separator, StringSplitOptions.None);
        int counter = Int32.Parse(parts[1].Trim());
        return counter;
    }

    void SetCountText(int counter)
    {
        string counter_label = String.Format("Total Number of Snacks left: {0}", counter);
        countSnack.text = counter_label;
    }
}
