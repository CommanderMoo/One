using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    //public float startSpeed = 10f;
    private Transform target;
    public float speed = 30f;
    private int wavepointIndex = 0;

    [HideInInspector]

    public float startHealth = 100;
    private float health;
    public int worth = 50;

    //public GameObject deathEffect;
    //[Header("Unity Stuff")]
    //public Image healthBar;
    //private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint.points[0];
        //speed = startSpeed;
        health = startHealth;
    }

    /*
    public void TakeDamage(float amount)
    {
        health -= amount;
        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

        public void Slow(float pct) 
        {
            speed = startSpeed * (1f - pct)
        }

        void Die()
        {
            isDead = true;
            PlayerStats.Money += worth;
            GameObject effect = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
        }
    */

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
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
}
