using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Здоровье врага
    public Material deathMaterial;
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
        // Получаем компонент системы уровней игрока и применяем опыт
        PlayerLevelSystem playerLevelSystem = FindObjectOfType<PlayerLevelSystem>();
        if (playerLevelSystem != null)
        {
            playerLevelSystem.GainExperience(50); // Например, при убийстве врага игрок получает 50 единиц опыта
        }

        GameObject deathEffect = new GameObject("DeathEffect");
        deathEffect.transform.position = transform.position;
        deathEffect.AddComponent<MeshRenderer>().material = deathMaterial;
        // Уничтожаем объект врага
        Destroy(gameObject);
    }

   
    public void IncreaseHP(float amount)
    {
        health -= amount;
    }
}
