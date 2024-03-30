using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Health : MonoBehaviour
{
    //private Armor armor;s
    public float currentHealth { get; private set; }
    public float maxHealth = 100;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
      //armor = GetComponent<Armor>();
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    //public virtual void TakeDamageArmor(float amount)
    //{
    //    float endDamage = armor.CountDamage(amount);
    //    TakeDamage(endDamage);
    //}

    public void Heal(float healValue)
    {
        currentHealth += healValue;
    }

    protected virtual void Death()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(100);
        }

        Destroy(gameObject);
    }
    
}