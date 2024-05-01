using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float damage = 50f; // ����, ������� ������� ����

    void OnCollisionEnter(Collision collision)
    {
        // ���� ���� ����������� � ������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ��������� ���� � �����
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // ���������� ����
            Destroy(gameObject);
        }
    }
}

