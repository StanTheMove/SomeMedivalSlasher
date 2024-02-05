using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationController : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform townCentre;

    public float detectionRange = 10f;
    public float damageAmount = 10f;
    public float stoppingDistance = 2f;
    public float attackCooldown = 1f;

    private NavMeshAgent agent;
    private bool Cooldown = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                agent.SetDestination(player.position);

                if (distanceToPlayer <= agent.stoppingDistance && !Cooldown)
                {
                    DamageDeal();
                    StartCoroutine(AttackCooldown());
                }
            }
            else
            {
                agent.SetDestination(townCentre.position);
            }
        }
        else
        {
            Debug.LogError("Player reference not set!"); 
        }
    }

    public void DamageDeal()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
    IEnumerator AttackCooldown()
    {
        Cooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        Cooldown = false;
    }
}
