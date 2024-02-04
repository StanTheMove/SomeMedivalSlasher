using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Armor armor;
    public float currentHealth { get; private set; } 
    public float maxHealth = 100;

    public HealthBar healthBar;

    private void Start()
    {
        armor = GetComponent<Armor>();
        currentHealth = maxHealth;
        healthBar.SetHealthValue(maxHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < damage || currentHealth <= 0)
        {
            Death();
        }
        healthBar.SetHealthValue(currentHealth / maxHealth);
    }

    public void TakeDamageArmor(float amount)
    {
        float endDamage = armor.CountDamage(amount);
        LowHeal(endDamage);
    }

    public void LowHeal(float damage) 
    {
        currentHealth -= damage;
    }
    
    public void Heal(float healValue)
    {
        currentHealth += healValue;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}