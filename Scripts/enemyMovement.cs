using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class enemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private enemy enemy;

    private void Start()
    {
        enemy = GetComponent<enemy>();

        target = Waypoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        //enemy.speed - enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

    void EndofPath()
    {
        Player.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }





}
