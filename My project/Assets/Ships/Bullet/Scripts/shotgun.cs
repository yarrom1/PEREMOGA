using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YourNamespace;

public class Shotgun : Projectile
{
    public int pelletCount = 10;
    public float spreadAngle = 10f;
    public GameObject pelletPrefab;

    void Start()
    {
        damage = 10f;
        fireRate = 1f;
        nextFireDelay = 1f;
        bulletForce = 10f;
    }

    void OnCollisionEnter(Collision collision)
    {
        OnHit(collision);
    }

    public override void OnHit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0));
            GameObject pellet = Instantiate(pelletPrefab, transform.position, rotation);
            Rigidbody rb = pellet.GetComponent<Rigidbody>();
            rb.AddForce(pellet.transform.forward * bulletForce, ForceMode.Impulse);
        }
    }
    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }
}
