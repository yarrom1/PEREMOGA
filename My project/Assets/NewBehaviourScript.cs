using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint; // �����, ������ ����� ����������� ����

    public float bulletForce = 10f; // ���� �������� ����
    public float maxBulletDistance = 500f;

 

    void Update()
    {
        // ��� ������� ����� ������ ����
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // �������� ����� ��������
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

   
   



}



