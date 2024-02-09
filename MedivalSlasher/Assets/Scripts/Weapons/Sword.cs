using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : MonoBehaviour
{
    public Transform Enemy;
    public GameObject Sword_DH;
    public int attackDamage = 5;
    public float attackRange = 3f;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwordSwing());
            SwordAttack();
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
    Sword_DH.GetComponent<Animator>().Play("New Animation");
    yield return new WaitForSeconds(1.0f);
    Sword_DH.GetComponent<Animator>().Play("New State");
    }
}
