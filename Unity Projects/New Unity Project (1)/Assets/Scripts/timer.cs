using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timeText;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
 
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timeText.text = minutes + ":" + seconds;
        float timeLimit = 20.00f;
        if (t > timeLimit)
        {
            FindObjectOfType<Load>().gameWon();
        }
    }


}
//Youtube. 2020. How To Create A Timer [Tutorial][C#] - Unity 3D. [online] Available at: <https://www.youtube.com/watch?v=x-C95TuQtf0> [Accessed 20 May 2020].