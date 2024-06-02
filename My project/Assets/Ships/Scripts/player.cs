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
    public float shieldMaxBoost = 0f; // ”величение максимального количества щита
    public float shieldRegenBoost = 0f; // ”величение скорости восстановлени€ щита
    void Start()
    {
        currentShield = maxShield + shieldMaxBoost;
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
        while (currentShield < maxShield + shieldMaxBoost)
        {
            currentShield += (shieldRegenRate + shieldRegenBoost) * Time.deltaTime;
            currentShield = Mathf.Clamp(currentShield, 0, maxShield + shieldMaxBoost);
            yield return new WaitForSeconds(0.1f);
        }
        regenShieldCoroutine = null;
    }

    public void IncreaseShieldMax(float amount)
    {
        maxShield += amount;
        currentShield = Mathf.Clamp(currentShield, 0, maxShield);
    }

    public void IncreaseShieldRegenRate(float amount)
    {
        shieldRegenRate += amount;
    }
}
