using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Transform Enemy;
    public GameObject spear;
    public int attackDamage = 7;
    public float attackRange = 10f;
    public LayerMask enemyLayer;
    private bool canAttack = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(SpearSwing());
            SpearAttack();
            canAttack = false;
        }
    }
    void SpearAttack()
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

    IEnumerator SpearSwing()
    {
        spear.GetComponent<Animator>().Play("New Animation");
        yield return new WaitForSeconds(0.4f);
        canAttack = true;
        spear.GetComponent<Animator>().Play("New State");
    }
}
