using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNeedles : MonoBehaviour
{
    [SerializeField] public int infectionCount = 0;
    public InfectionBar infection;
  

    void Start()
    {
        infection.setMax(200, infectionCount);
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            infectionCount++;
            infection.changeInfection(infectionCount);

            if (infectionCount == 200)
            {
                FindObjectOfType<Load>().loadGameOver();
            }
        }
        Destroy(collision.gameObject);
    }

    // Update is called once per frame
 
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].

//YouTube. 2020. How To Make A HEALTH BAR In Unity!. [online] Available at: <https://www.youtube.com/watch?v=BLfNP4Sc_iA> [Accessed 20 May 2020].