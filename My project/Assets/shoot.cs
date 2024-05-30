using System.Collections;
using UnityEngine;
using YourNamespace;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject shotgunPelletPrefab;
    public LineRenderer laserPrefab;

    public Transform[] firePoints; 
    private Projectile currentProjectile;
    private float nextFireTime = 0f;

    private enum ProjectileType { Bullet, Rocket, Shotgun, MachineGun, Laser }

    void Start()
    {
        ChangeProjectileType("Bullet");
    }

    void Update()
    {
        if (Time.time >= nextFireTime && Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
            nextFireTime = Time.time + currentProjectile.nextFireDelay;
        }
    }

    public void ChangeProjectileType(string type)
    {
        switch (type)
        {
            case "rocket":
                currentProjectile = rocketPrefab.GetComponent<Rocket>();
                break;
            case "shotgun":
                currentProjectile = shotgunPelletPrefab.GetComponent<Shotgun>();
                break;
            case "laser":
                currentProjectile = laserPrefab.GetComponent<Laser>();
                break;
            default:
                currentProjectile = bulletPrefab.GetComponent<Bullet>();
                break;
        }
    }

    void ShootProjectile()
    {
        if (currentProjectile == null) return;

        foreach (Transform firePoint in firePoints)
        {
            GameObject projectileInstance = Instantiate(currentProjectile.gameObject, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * currentProjectile.bulletForce, ForceMode.Impulse);
            StartCoroutine(DestroyProjectile(projectileInstance));

            if (projectileInstance.GetComponent<Shotgun>() != null)
            {
                projectileInstance.GetComponent<Shotgun>().Shoot();
            }
        }
    }

    IEnumerator DestroyProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(5f);
        Destroy(projectile);
    }

    public void IncreaseFireRate(float amount)
    {
        if (currentProjectile != null)
        {
            currentProjectile.fireRate -= amount;
        }
    }
}
