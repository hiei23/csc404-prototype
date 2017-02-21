using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _GameController : MonoBehaviour
{

    public float time;
    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        SetText();

    }

    void SetText()
    {

        if (time > 0)
        {

            text.text = string.Format("{0}:{1:00}", Mathf.Floor(time / 60), Mathf.Floor(time % 60));
        }
        else
        {
            text.text = "0:00";
        }
    }

}
