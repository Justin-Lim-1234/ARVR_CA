using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RobotPrefab;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    private Waypoints robotvalues;
    private int count= 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRobotLvl3();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRobotLvl1()
    {
        DestroyExistingRobot();
        count = 1;
        for (int i = 0; i < count; i++)
        {
            GameObject robot = Instantiate(RobotPrefab, SpawnPoint1.transform);
            robotvalues = robot.GetComponent<Waypoints>();
            robotvalues.LevelofBot = 1;
            robotvalues.speed = 2;
        }


    }

    public void SpawnRobotLvl2()
    {
        DestroyExistingRobot();
        count = 1;
        for (int i = 0; i < count; i++)
        {
            GameObject robot = Instantiate(RobotPrefab, SpawnPoint2.transform);
            robotvalues = robot.GetComponent<Waypoints>();
            robotvalues.LevelofBot = 2;
            robotvalues.speed = 4;
        }


    }

    public void SpawnRobotLvl3()
    {
        DestroyExistingRobot();
        count = 1;
        for (int i = 0; i < count; i++)
        {
            GameObject robot = Instantiate(RobotPrefab, SpawnPoint3.transform);
            robotvalues = robot.GetComponent<Waypoints>();
            robotvalues.LevelofBot = 3;
            robotvalues.speed = 7;
            robotvalues.rangeWaypoints = 0.7f;
        }


    }


    public void DestroyExistingRobot()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        for (int i = 0; i < robots.Length; i++)
        {

            Destroy(robots[i]);
        }

    }
}

