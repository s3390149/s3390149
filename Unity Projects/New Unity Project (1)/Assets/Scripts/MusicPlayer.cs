using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].