using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform player; // ������ �� ������
    public float spawnInterval = 5f; // �������� ������ ������
    public float spawnDistance = 10f; // ���������� ������ �� ������

    void Start()
    {
        // �������� �������� ������
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ��������� ������� ������ �����
            Vector3 spawnPosition = player.position + Random.onUnitSphere * spawnDistance;
            spawnPosition.y = player.position.y; // ������������� ������ ������ ������ ������ ������

            // ������� ��������� ����� �� �������
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // ��������� ������ Enemy � �����
            enemy.AddComponent<Enemy>();
        

            // ������������� ��� Enemy ��� �����
            enemy.tag = "Enemy";

            // ���� �������� �������� ����� ��������� �������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}

