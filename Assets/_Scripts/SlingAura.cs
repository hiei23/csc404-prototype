using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingAura : MonoBehaviour {

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

        if ((Input.GetAxisRaw("ReturnP1") == 1) && (parent.CompareTag("Player1")))
        {
            ps.Play();
            return;
        }

        if ((Input.GetAxisRaw("ReturnP2") == 1) && (parent.CompareTag("Player2")))
        {
            ps.Play();
            return;
        }

        ps.Stop();
    }
}
