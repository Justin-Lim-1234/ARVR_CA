using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    private float health;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    private void HealthManager()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }
}
