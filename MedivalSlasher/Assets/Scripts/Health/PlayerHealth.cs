using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public HealthBar healthBar;

    void Start()
    {
        base.Start();
        healthBar.SetHealthValue(maxHealth / maxHealth);
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealthValue(currentHealth / maxHealth);
    }
}
