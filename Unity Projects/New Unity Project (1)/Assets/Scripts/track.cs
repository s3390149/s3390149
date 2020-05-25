using UnityEngine;
using System.Collections;

public class track : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }
}

//https://answers.unity.com/questions/971104/unity-2d-c-script-follows-the-enemy-player.html 