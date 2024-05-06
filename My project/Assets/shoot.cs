using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, откуда будут выпускаться пули

    public float bulletForce = 10f; // Сила выстрела пули
    public float maxBulletDistance = 500f;
    public float fireRate = 1f; // Скорострельность: время между выстрелами
    private float nextFireTime = 0f; // Время следующего возможного выстрела

    void Update()
    {
        // Проверяем, можно ли стрелять сейчас
        if (Time.time >= nextFireTime)
        {
            // При нажатии левой кнопки мыши
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(); // Вызываем метод выстрела
                nextFireTime = Time.time + fireRate; // Обновляем время следующего возможного выстрела
            }
        }
    }

    void Shoot()
    {
        // Создаем экземпляр пули из префаба
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получаем компонент Rigidbody для пули
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Применяем силу выстрела к пуле
        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

  
        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
  
        yield return new WaitForSeconds(5f); 

        Destroy(bullet);
    }


    void OnCollisionEnter(Collision collision)
    {
        // Если игрок столкнулся с врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
          
            Debug.Log("Игра окончена");
        }
    }


    public void IncreaseFireRate(float amount)
    {
        fireRate -= amount;
    }
}



