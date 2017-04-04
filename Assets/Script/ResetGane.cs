using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGane : MonoBehaviour {

    private string MAIN_MENU_SCENE = "Title";
    AudioSource start_button_sound;
    // Use this for initialization
    void Start()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        start_button_sound = sources[0];
        start_button_sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            start_button_sound.Play();
            SceneManager.LoadScene(MAIN_MENU_SCENE);   
        }

    }
}
