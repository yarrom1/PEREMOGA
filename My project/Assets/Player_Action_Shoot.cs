using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, откуда будут выпускаться пули

    public float bulletForce = 10f; // Сила выстрела пули
    public float maxBulletDistance = 500f;
    void Update()
    {
        // При нажатии левой кнопки мыши
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // Вызываем метод выстрела
        }
    }

    void Shoot()
    {
        // Создаем экземпляр пули из префаба
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получаем компонент Rigidbody для пули
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        // Отключаем гравитацию для пули
        bulletRb.useGravity = false;

        // Отключаем коллизии между пулями
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        // Применяем силу выстрела к пуле
        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        float distanceTraveled = 0f;

        while (distanceTraveled < maxBulletDistance)
        {
            // Обновляем расстояние
            distanceTraveled += bullet.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;

            yield return null;
        }

        // Удаляем пулю, если она преодолела максимальное расстояние
        Destroy(bullet);
    }
}
