using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainLevel : MonoBehaviour {

    // Use this for initialization
    private string MAIN_LEVEL = "level2_map1";
    AudioSource start_button_sound;

    void Start () {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        start_button_sound = sources[0];
        start_button_sound.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            start_button_sound.Play();
            SceneManager.LoadScene(MAIN_LEVEL);
        }
            
    }
}