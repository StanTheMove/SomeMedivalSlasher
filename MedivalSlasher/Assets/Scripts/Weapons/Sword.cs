using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform Enemy;
    public GameObject Sword_DH;
    public int attackDamage = 5;
    public float attackRange = 3f;
    public LayerMask enemyLayer;

    private bool canAttack = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(SwordSwing());
            SwordAttack();
            canAttack = false;
        }
    }
    void SwordAttack()
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

    IEnumerator SwordSwing()
    {
        Sword_DH.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(0.7f);
        canAttack = true;
        Sword_DH.GetComponent<Animator>().Play("New State");
    }
}
