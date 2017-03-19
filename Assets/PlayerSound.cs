using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    float MAX_PLAY_TIME = 1.0f;
    AudioSource jump1, jump2;
    // Use this for initialization
    float jump1Time, jump2Time;
    bool playingJump1, playingJump2;
	void Start () {

        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        jump1 = sources[1];
        jump2 = sources[0];
        jump1.Stop();
        jump2.Stop();
        jump1Time = MAX_PLAY_TIME;
        jump2Time = MAX_PLAY_TIME;
        playingJump1 = false;
        playingJump2 = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("JumpP1") || Input.GetButton("JumpP2"))
        {
            if (jump1Time == MAX_PLAY_TIME)
            {
                jump1.Play();
                playingJump1 = true;
            }

            if (jump1Time < 0.0f)
            {
                jump1Time = MAX_PLAY_TIME;
                playingJump1 = false;
            }
        }

        if (playingJump1)
        {
            jump1Time -= Time.deltaTime;
        }

        if (Input.GetButton("ThrowP1") || Input.GetButton("ThrowP2"))
        {
            if (jump2Time == MAX_PLAY_TIME)
            {
                jump2.Play();
                playingJump2 = true;
            }

            if (jump2Time < 0.0f)
            {
                jump2Time = MAX_PLAY_TIME;
                playingJump2 = false;
            }
        }

        if (playingJump2)
        {
            jump2Time -= Time.deltaTime;
        }
    }
}
