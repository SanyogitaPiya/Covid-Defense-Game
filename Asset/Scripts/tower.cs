using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenShots;

    private GameObject currentTarget;

    private float nextTimeShoot;


    private void Start()
    {
        nextTimeShoot = Time.time;
    }

    //function for tower to detect the nearest enemy
    private void updateNearestEnemy()
    {
        GameObject nearestEnemy = null;

        float distance = Mathf.Infinity;

        foreach(GameObject covid in EnemyList.covids)
        {
            if (covid != null)
            {
                float _distance = (transform.position - covid.transform.position).magnitude;

                if (_distance < distance)
                {
                    distance = _distance;
                    nearestEnemy = covid;
                }
            }
            
        }

        if (distance <= range)
        {
            currentTarget = nearestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }

    private void shoot()
    {
        Character covidScript = currentTarget.GetComponent<Character>();

        covidScript.takeDamage(damage);
    }

    private void Update()
    {
        updateNearestEnemy();

        if (Time.time >= nextTimeShoot)
        {
            if (currentTarget != null)
            {
                shoot();
                nextTimeShoot = Time.time + timeBetweenShots;
            }
        }
    }
}
