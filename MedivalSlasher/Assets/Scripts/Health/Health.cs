using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth = 100;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < damage || currentHealth <= 0)
        {
            Death();
        }
    }
    
    public void Heal(float healValue)
    {
        currentHealth += healValue;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public void Death()
    {
        Destroy(gameObject);
    }

    private void TestHealth()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
    }
}