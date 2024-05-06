using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint; // �����, ������ ����� ����������� ����

    public float bulletForce = 10f; // ���� �������� ����
    public float maxBulletDistance = 500f;
    public float fireRate = 1f; // ����������������: ����� ����� ����������
    private float nextFireTime = 0f; // ����� ���������� ���������� ��������

    void Update()
    {
        // ���������, ����� �� �������� ������
        if (Time.time >= nextFireTime)
        {
            // ��� ������� ����� ������ ����
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(); // �������� ����� ��������
                nextFireTime = Time.time + fireRate; // ��������� ����� ���������� ���������� ��������
            }
        }
    }

    void Shoot()
    {
        // ������� ��������� ���� �� �������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �������� ��������� Rigidbody ��� ����
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // ��������� ���� �������� � ����
        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

  
        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
  
        yield return new WaitForSeconds(5f); 

        Destroy(bullet);
    }


    void OnCollisionEnter(Collision collision)
    {
        // ���� ����� ���������� � ������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
          
            Debug.Log("���� ��������");
        }
    }


    public void IncreaseFireRate(float amount)
    {
        fireRate -= amount;
    }
}



