using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfiguration> Waves;
    int startingWave = 0;
    [SerializeField] bool looping = false;
    IEnumerator Start()
    {
        //getting the current wave and passing it to a coroutine
        do
        {

            yield return StartCoroutine(SpawnEnemyWaves());

        }
        while (looping);
        
        }
    private IEnumerator SpawnEnemyWaves()
    {   //this is set to the amount of waves that are available, this then triggers the next 
        //coroutine to run the wave.
        for (int waveIndex = startingWave; waveIndex < Waves.Count; waveIndex++)
        {
            var currentWave = Waves[waveIndex];
            yield return StartCoroutine(SpawnEnemyWaves(currentWave));
        }
    }
    // Update is called once per frame
    //this is to spawn enemies within the wave by using the coroutine
 private IEnumerator SpawnEnemyWaves(WaveConfiguration WaveConfiguration)
    {
        //for loop enemy count less than the current wave configuration enemy count.
        for (int enemycount = 0; enemycount < WaveConfiguration.getNumberOfEnemies(); enemycount++)
        {
            //store enemy prefab from wave config into variable at the start way point indicated by the index 0, quaternion identity is current rotation
           var newEnemy = Instantiate(WaveConfiguration.getEnemyPrefab(), WaveConfiguration.getWayPoints()[0].transform.position, Quaternion.identity);
            //mutator in the enemyPath class to set the wave config to the wave configuration here
            newEnemy.GetComponent<EnemyPath>().SetWave(WaveConfiguration);
            //wait for amount set in wave configurations
            yield return new WaitForSeconds(WaveConfiguration.getTimeBetweenSpawns());

        }
        }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games.
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].