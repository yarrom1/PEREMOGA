using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YourNamespace;

public class Rifle : Projectile
{
    public GameObject bulletPrefab;

    void Start()
    {
        damage = 25f;
        fireRate = 0.2f;
        nextFireDelay = fireRate;
        bulletForce = 35f;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireDelay)
        {
            nextFireDelay = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
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

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }
}
