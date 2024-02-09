using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 20;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Heal();
        }
    }

    void Heal()
    {
        Health currentHealth = GetComponent<Health>();
        if (currentHealth != null)
        {
            currentHealth.Heal(healAmount);
        }
        Destroy(gameObject);
    }
}
