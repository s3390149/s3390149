using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class ToiletRoll : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().addToScore(1000);
            FindObjectOfType<Load>().gameWon();
        }
    }
}
