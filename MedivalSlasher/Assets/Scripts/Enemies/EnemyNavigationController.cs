using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Enemies
{
    public class EnemyNavigationController : MonoBehaviour
    {
        public Transform townCentre;
        public Transform player;

        public float detectionRange = 10f;
        public float damageAmount = 10f;
        public float stoppingDistance = 2f;
        public float attackCooldown = 1f;

        private NavMeshAgent agent;
        private bool Cooldown = false;
        public float agentSpeed = 5f;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = stoppingDistance;
            agent.speed = agentSpeed;
        }

        private void Update()
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
}
