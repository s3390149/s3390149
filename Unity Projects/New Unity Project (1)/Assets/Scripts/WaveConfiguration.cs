using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is to make a scriptable object when going to create "new"
[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfiguration : ScriptableObject { 

    //Enemy and path prefab serialised so each can be dropped into the wave config scriptable object

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;


    [SerializeField] float timeBetweenSPawns = 0.5f;
    [SerializeField] float spawnRandomly = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    //accessors
    public GameObject getEnemyPrefab ()
    {
        return enemyPrefab;
    }
    //list is used as its not fixed like an array
    public List<Transform> getWayPoints ()
    {
        //making a new list of transforms
        var waveWayPoints = new List<Transform>();
        //for each transform child in the path prefab (containing waypoints) transform 
        foreach(Transform child in pathPrefab.transform) 
        {
            waveWayPoints.Add(child);
            //add transforms of each way point to the way point variable list
        }

        return waveWayPoints;

    }

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSPawns;
    }

    public float getspawnRandomly()
    {
        return spawnRandomly;
    }

    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float getEnemyMoveSpeed()
    {
        return moveSpeed;
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].