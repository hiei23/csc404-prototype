using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    // Use this for initialization
    private ParticleSystem ps;
    private Component parent;
    void Start()
    {
        Component child;
        parent = GetComponentInParent<Rigidbody>();
        child = GetComponentInChildren<ParticleSystem>();
        ps = child.GetComponent<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetAxisRaw("JumpP1") == 1) && (parent.CompareTag("Player1")))
        {
            ps.Play();
            return;
        }

        if ((Input.GetAxisRaw("JumpP2") == 1) && (parent.CompareTag("Player2")))
        {
            ps.Play();
            return;
        }

        ps.Stop();
    }
}