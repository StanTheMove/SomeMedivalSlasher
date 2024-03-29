using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public Transform Enemy;
    public GameObject axe;
    public int attackDamage = 12;
    public float attackRange = 6f;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AxeAnim());
            AxeDamage();
        }
    }
    void AxeDamage()
    {
        Collider[] hitEnemy = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemy)
        {
            Health Health = enemy.GetComponent<Health>();
            if (Health != null)
            {
                Health.TakeDamage(attackDamage);
            }
        }
    }

    IEnumerator AxeAnim()
    {
        axe.GetComponent<Animator>().Play("AxeAttacks");
        yield return new WaitForSeconds(3.0f);
        axe.GetComponent<Animator>().Play("New State");
    }
}
