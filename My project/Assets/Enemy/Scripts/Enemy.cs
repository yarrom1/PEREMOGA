using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // �������� �����
    public Material deathMaterial;
    public void TakeDamage(float damage)
    {
        health -= damage; // ��������� �������� �����

        // ���� �������� ����� ������ ��� ����� ����
        if (health <= 0f)
        {
            Die(); // �������� ����� ������
        }
    }

    void Die()
    {
        // �������� ��������� ������� ������� ������ � ��������� ����
        PlayerLevelSystem playerLevelSystem = FindObjectOfType<PlayerLevelSystem>();
        if (playerLevelSystem != null)
        {
            playerLevelSystem.GainExperience(50); // ��������, ��� �������� ����� ����� �������� 50 ������ �����
        }

        GameObject deathEffect = new GameObject("DeathEffect");
        deathEffect.transform.position = transform.position;
        deathEffect.AddComponent<MeshRenderer>().material = deathMaterial;
        // ���������� ������ �����
        Destroy(gameObject);
    }

   
    public void IncreaseHP(float amount)
    {
        health -= amount;
    }
}
