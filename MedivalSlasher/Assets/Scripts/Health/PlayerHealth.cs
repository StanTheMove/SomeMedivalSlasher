using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public HealthBar healthBar;
    public TheEndGame endGame;
    public Action OnPlayerDeath;

    void Start()
    {
        Init();
    }
    
    protected override void Init()
    {
        base.Init();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        healthBar.SetHealthValue(maxHealth / maxHealth); 
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealthValue(currentHealth / maxHealth);
    }
    //public override void TakeDamageArmor(float amount)
    //{
    //    base.TakeDamageArmor(amount);
    //}
    protected override void Death()
    {
        OnPlayerDeath?.Invoke();
        base.Death();
    }
    public void HandlePlayerDeath()
    {
        OnPlayerDeath += endGame.EndGame;

    }
}
