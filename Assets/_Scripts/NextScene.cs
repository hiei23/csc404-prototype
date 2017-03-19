using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class NextScene : MonoBehaviour {

    public int sceneIndex = 0;
    
    AudioSource background_music;
    AudioSource start_button_sound;
    // Use this for initialization
    void Start () {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        background_music = sources[1];
        start_button_sound = sources[0];
        start_button_sound.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            background_music.volume = 0.1f;
            start_button_sound.Play();
            background_music.volume = 0.5f;
            SceneManager.LoadScene(sceneIndex);
        }
       
    }
}
