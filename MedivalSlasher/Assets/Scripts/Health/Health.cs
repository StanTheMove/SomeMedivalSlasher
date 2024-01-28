using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth { get; private set; } 
    [SerializeField] private float maxHealth = 100;

    private void Start()
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

    private void Death()
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