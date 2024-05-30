using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour
{
    public float maxShield = 100f;
    public float currentShield;
    public float shieldRegenRate = 10f;
    public float shieldRegenDelay = 5f;
    public float maxHealth = 100f;
    public float currentHealth;
    private Coroutine regenShieldCoroutine;

    void Start()
    {
        currentShield = maxShield;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentShield < maxShield && regenShieldCoroutine == null)
        {
            currentShield += shieldRegenRate * Time.deltaTime;
            currentShield = Mathf.Clamp(currentShield, 0f, maxShield);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if (regenShieldCoroutine != null)
        {
            StopCoroutine(regenShieldCoroutine);
        }

        if (currentShield > 0)
        {
            currentShield -= damage;
            if (currentShield < 0)
            {
                currentHealth += currentShield;
                currentShield = 0;
            }
        }
        else
        {
            currentHealth -= damage;
        }

        regenShieldCoroutine = StartCoroutine(RegenShield());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float damage = 10f;
            TakeDamage(damage);
        }
    }

    IEnumerator RegenShield()
    {
        yield return new WaitForSeconds(shieldRegenDelay);
        regenShieldCoroutine = null;
    }
}
