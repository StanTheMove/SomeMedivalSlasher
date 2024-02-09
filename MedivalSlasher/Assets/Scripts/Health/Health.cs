using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Armor armor;
    public float currentHealth { get; private set; } 
    public float maxHealth = 100;
    public Vector2 respawnPosition = new Vector2(0, 0);

    protected void Start()
    {
        armor = GetComponent<Armor>();
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < damage || currentHealth <= 0)
        {
            Death();
        }
    }

    public virtual void TakeDamageArmor(float amount)
    {
        float endDamage = armor.CountDamage(amount);
        TakeDamage(endDamage);
    }
    
    public void Heal(float healValue)
    {
        currentHealth += healValue;
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Die()
    {
        respawnPosition = new
        Vector2(Random.Range(-10f, 10f), Random.Range(-10, 10f));
    }
}