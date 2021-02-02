using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    private enemy targetEnemy;

    [Header("General")]
    public float range = 50f;



    [Header("Use Bullets")]
    // 50 is questionable now 75 needs to be tested 12/6
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    /*
    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOvertime = 30;
    public float slowAmount = .5f;
    */

    //[Header("Attributes")]
    
    

    [Header("Unity Setup Fields")]
    public string enemyTag = "enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            // enemy found and in range
            if (nearestEnemy != null && shortestDistance <= range)
            {
                // target closest target
                target = nearestEnemy.transform;
            } else
            {
                target = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // this is the lock functions note the methods
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        Debug.Log("Shoot");
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
