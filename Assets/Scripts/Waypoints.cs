using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private GameObject [] LevelWaypoints;
    public int LevelofBot = 0;
    public float  rangeWaypoints = 2;
    private GameObject currentWaypointTarget;
    private int index;
    public float speed = 5;
    public RobotScript robot;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        LevelWaypoints = GameObject.FindGameObjectsWithTag("WaypointsLevel" + LevelofBot);
        currentWaypointTarget = LevelWaypoints[index];
        print("No. of Waypoints is " + LevelWaypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {


        if (!robot.dead)
        {
            if (Vector3.Distance(transform.position, LevelWaypoints[index].transform.position) < rangeWaypoints)
            {
                index++;
                if (index >= LevelWaypoints.Length)
                {
                    index = 0;
                }

            }
            else
            {
                // Move our position a step closer to the target.
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, LevelWaypoints[index].transform.position, step);
            }
        }
        
      

    }
}
