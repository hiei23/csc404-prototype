﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    // Use this for initialization
    public ParticleSystem jumpAura;
    public ParticleSystem slingAura;
    private Component parent;

    void Start()
    {
        Component child;
        parent = GetComponent<Rigidbody>();
        slingAura.Stop();
        jumpAura.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetAxisRaw("JumpP1") == 1) && (parent.CompareTag("Player1")))
        {
            jumpAura.Play();
            return;
        }

        if ((Input.GetAxisRaw("JumpP2") == 1) && (parent.CompareTag("Player2")))
        {
            jumpAura.Play();
            return;
        }

        if ((Input.GetAxisRaw("ReturnP1") == 1) && (parent.CompareTag("Player1")))
        {
            slingAura.Play();
            return;
        }

        if ((Input.GetAxisRaw("ReturnP2") == 1) && (parent.CompareTag("Player2")))
        {
            slingAura.Play();
            return;
        }

        slingAura.Stop();
        jumpAura.Stop();
    }
}