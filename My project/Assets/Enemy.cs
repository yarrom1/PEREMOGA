using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // �������� �����

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

        // ���������� ������ �����
        Destroy(gameObject);
    }

   
    public void IncreaseHP(float amount)
    {
        health -= amount;
    }
}
