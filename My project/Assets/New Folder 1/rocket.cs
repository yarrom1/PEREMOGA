using UnityEngine;
using YourNamespace;

public class Rocket : Projectile
{
    public float explosionRadius = 5f;

    void Start()
    {
        damage = 50f;
        fireRate = 0.5f;
        nextFireDelay = 0.5f;
        bulletForce = 15f;
    }

    void OnCollisionEnter(Collision collision)
    {
        OnHit(collision);
    }

    public override void OnHit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider nearbyObject in colliders)
            {
                Enemy enemy = nearbyObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }
}
