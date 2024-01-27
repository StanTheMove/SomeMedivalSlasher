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

    public void TakeDamage(float damageDealt)
    {
        currentHealth -= damageDealt;

        if(currentHealth < damageDealt || currentHealth <= 0)
        {
            Object.Destroy(gameObject);
        }
    }
    
    public void Heal(float heal)
    {
        currentHealth += heal;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void TestHealth()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
    }
}