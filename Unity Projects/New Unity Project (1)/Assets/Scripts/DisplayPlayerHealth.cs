using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerHealth : MonoBehaviour
{

    Text text;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.getPlayerLives().ToString();
    }


}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: 
//Learn to Code Making Games. Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].