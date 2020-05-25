using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    // Toilet roll
    public GameObject bogRoll;
    public float bogRollSpawnRate;
    private float nextBogRoll = 0.0f;
    private float nextBogRollSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextBogRoll)
        {
            setBogRollSpawn();
            StartCoroutine(spawnBogRoll());
        }
    }

    private void setBogRollSpawn()
    {
        nextBogRollSpawn = Random.Range(Random.Range(0, bogRollSpawnRate), Random.Range(bogRollSpawnRate, bogRollSpawnRate + 15));
        nextBogRoll = Time.time + nextBogRollSpawn;
    }

    IEnumerator spawnBogRoll()
    {
        Instantiate(bogRoll, new Vector3(Random.Range(-5, 5), 9.5f, 0), Quaternion.identity);

        yield return new WaitForSeconds(nextBogRoll);
    }
}
