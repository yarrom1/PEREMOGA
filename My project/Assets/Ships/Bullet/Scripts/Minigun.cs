using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YourNamespace;

public class Minigun : Projectile
{
    public int bulletsPerSecond = 20;
    public GameObject bulletPrefab;

    void Start()
    {
        damage = 10f;
        fireRate = 1f / bulletsPerSecond;
        nextFireDelay = fireRate;
        bulletForce = 25f;
        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
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
