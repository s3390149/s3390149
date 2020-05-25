using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 100;
    // Start is called before the first frame update
    public int getDamage()
    {
        return damage;
    }

    // Update is called once per frame
    public void hit()
    {
        Destroy(gameObject);
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games.
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].