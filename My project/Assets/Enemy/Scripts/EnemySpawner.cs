using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага

    public Transform player; // Ссылка на игрока
    public int enemiesPerWave = 5; // Количество врагов в одной волне
    public float waveInterval = 20f; // Интервал между волнами
    public float spawnDistance = 10f; // Расстояние спавна от игрока
    public float spawnInterval = 1f; // Интервал спавна внутри волны

 

    void Start()
    {
    


        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
                Vector3 spawnPosition =  Random.insideUnitSphere * 2f;
                spawnPosition.y = player.position.y;


                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);


                enemy.AddComponent<Enemy>();
                enemy.AddComponent<EnemyAI>();
 
                enemy.tag = "Enemy";


                yield return new WaitForSeconds(spawnInterval);
            }


            yield return new WaitForSeconds(waveInterval);
        }
    }
}
