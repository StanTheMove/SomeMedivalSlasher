using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
}
public class PlayerHealth : Health
{

}
public class EnemyHealth : Health
{

}
