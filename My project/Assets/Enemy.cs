using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Здоровье врага

    public void TakeDamage(float damage)
    {
        health -= damage; // Уменьшаем здоровье врага

        // Если здоровье врага меньше или равно нулю
        if (health <= 0f)
        {
            Die(); // Вызываем метод смерти
        }
    }

    void Die()
    {
        // Уничтожаем объект врага
        Destroy(gameObject);
    }
}

