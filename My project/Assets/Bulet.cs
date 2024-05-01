using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float damage = 50f; // Урон, который наносит пуля

    void OnCollisionEnter(Collision collision)
    {
        // Если пуля столкнулась с врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Применяем урон к врагу
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Уничтожаем пулю
            Destroy(gameObject);
        }
    }
}


