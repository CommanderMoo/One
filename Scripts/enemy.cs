﻿using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{

    //public float startSpeed = 10f;
    private Transform target;

    [HideInInspector]
    public float speed = 30f;

    public float startHealth = 100;
    private float health;

    public int worth = 50;
    //public GameObject deathEffect;
    //private int wavepointIndex = 0;

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

   
}
