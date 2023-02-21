using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float covidHealth;

    public int killReward;

    public int damage;



    public float speed;
    private Waypoints wpoints;

    private int waypointIndex;

    //reference EnemyList script
    private void Awake()
    {
        EnemyList.covids.Add(gameObject);
    }

    void Start()
    {
        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        //this block of code is to rotate the covid asset as it moves through the waypoints
        Vector3 direction = wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //check if covid asset has moved to waypoint and if so, move to next waypoint
        if(Vector2.Distance(transform.position, wpoints.waypoints[waypointIndex].position) < 0.1f)

            //if covid unit has not moved to last waypoint, then icnrement index to move to next waypoint
            if(waypointIndex < wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            //if covid unit has arrived at the last waypoint, then destroy the asset object
            else
            {
                Destroy(gameObject);
            }       
    }


    //functions from playlist

    //function for covid to take damage
    public void takeDamage(float damageAmount)
    {
        covidHealth -= damageAmount;

        if (covidHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    //when covid dies
    private void die()
    {
        EnemyList.covids.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private void initializeEnemy()
    {

    }

    private void moveEnemy()
    {

    }
}
