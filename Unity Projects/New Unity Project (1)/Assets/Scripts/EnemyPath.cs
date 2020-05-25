using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    //get the waveconfiguration 
    WaveConfiguration WaveConfig;
    //make a new list for waypoints
    List<Transform> WayPoints;
 
    int wayPointIndex = 0;
    void Start()
    {
        
        //use accessor to get each way point transform position 
        WayPoints = WaveConfig.getWayPoints();
        //this is reffering to the enemy and using the list of waypoints transform.position and setting the enemies position
        //to each waypoint
        transform.position = WayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWave(WaveConfiguration waveConfiguration)
    {
        this.WaveConfig = waveConfiguration;
    }

    private void Move()
    {
        //count is used and not length because the list length is dynamic and not fixed
        if (wayPointIndex <= WayPoints.Count - 1)
        {
            //target position is the current waypoint (waypoint index) on the waypoints list (line 10) and get the current position
            var targetPos = WayPoints[wayPointIndex].transform.position;
            //enemy travelling speed is move speed by frame execution rate
            var movement = WaveConfig.getEnemyMoveSpeed() * Time.deltaTime;

            //enemies will move towards target position from the current position at the movement speed using MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movement);

            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].