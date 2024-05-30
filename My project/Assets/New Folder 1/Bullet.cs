using UnityEngine;
using YourNamespace;

public class Bullet : Projectile
{
    void Start()
    {
        damage = 15f;
        fireRate = 0.1f;
        nextFireDelay = 0.1f;
        bulletForce = 20f;
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
