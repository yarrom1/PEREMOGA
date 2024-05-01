using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform player; // Ссылка на игрока
    public float spawnInterval = 5f; // Интервал спавна врагов
    public float spawnDistance = 10f; // Расстояние спавна от игрока

    void Start()
    {
        // Начинаем спавнить врагов
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Вычисляем позицию спавна врага
            Vector3 spawnPosition = player.position + Random.onUnitSphere * spawnDistance;
            spawnPosition.y = player.position.y; // Устанавливаем высоту спавна равной высоте игрока

            // Создаем экземпляр врага из префаба
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Добавляем скрипт Enemy к врагу
            enemy.AddComponent<Enemy>();
        

            // Устанавливаем тег Enemy для врага
            enemy.tag = "Enemy";

            // Ждем заданный интервал перед следующим спавном
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}

