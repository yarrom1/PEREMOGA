using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����

    public Transform player; // ������ �� ������
    public int enemiesPerWave = 5; // ���������� ������ � ����� �����
    public float waveInterval = 20f; // �������� ����� �������
    public float spawnDistance = 10f; // ���������� ������ �� ������
    public float spawnInterval = 1f; // �������� ������ ������ �����

 

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
