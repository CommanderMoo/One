using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0;
    public GameObject bulletImpact;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {

        Debug.Log("Hit");
        GameObject effectIns = (GameObject)Instantiate(bulletImpact, transform.position, transform.rotation);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);

    }
   
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
