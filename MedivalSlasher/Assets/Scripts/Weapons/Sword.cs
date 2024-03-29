using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Sword_DH;
    public int attackDamage = 5;
    public float attackRange = 3f;
    public LayerMask enemyLayer;

    private bool canAttack = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(SwordAttack());
            StartCoroutine(SwordSwing());
            canAttack = false;
        }
    }

    IEnumerator SwordAttack()
    {
        yield return new WaitForSeconds(2f); // Cooldown duration
        canAttack = true;
    }

    IEnumerator SwordSwing()
    {
        Sword_DH.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(2f);
        Sword_DH.GetComponent<Animator>().Play("New State");
    }
}
