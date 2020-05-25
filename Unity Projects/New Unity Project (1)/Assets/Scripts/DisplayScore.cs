using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    Text scoreText;
    GameSession gamesession;

    // Start is called before the first frame update
    void Start()
    {
        gamesession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gamesession.getScore().ToString();
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: 
//Learn to Code Making Games. Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].