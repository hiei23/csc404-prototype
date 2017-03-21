using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGane : MonoBehaviour {

    public int sceneIndex = 0;
    private string MAIN_MENU_SCENE = "Title";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);   
        }

    }
}
