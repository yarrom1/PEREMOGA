using UnityEngine;
using YourNamespace;

public class Pellet : Projectile
{

    void Start()
    {
        damage = 20f;
        
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
}
