using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YourNamespace;

public class Laser : Projectile
{
    public LineRenderer lineRenderer;
    public float maxDistance = 100f;

    void Start()
    {
        damage = 5f;
        fireRate = 0.1f;
        nextFireDelay = 0.1f;
        bulletForce = 0f; // Не используется
    }

    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * maxDistance;

        lineRenderer.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage * Time.deltaTime);
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + forward);
        }
    }

    public override void OnHit(Collision collision)
    {
        // Не используется в этом случае
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }
}
