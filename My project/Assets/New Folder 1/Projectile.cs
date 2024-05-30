using UnityEngine;

namespace YourNamespace
{
    public abstract class Projectile : MonoBehaviour
    {
        public float damage;
        public float fireRate;
        public float nextFireDelay;
        public float bulletForce;

        public abstract void OnHit(Collision collision);
    }
}
