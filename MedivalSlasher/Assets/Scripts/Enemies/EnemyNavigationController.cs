using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace Enemies
{
    public class EnemyNavigationController : MonoBehaviour
    {
        private Transform townCentre;
        public Transform player;
        public Action OnPlayerRespawn;

        private EnemySearchControll searchControll;

        public float detectionRange = 10f;
        public float damageAmount = 10f;
        public float stoppingDistance = 2f;
        public float attackCooldown = 1f;

        private NavMeshAgent agent;
        private bool Cooldown = false;
        public float agentSpeed = 5f;

        private void Start()
        {   
            searchControll = GetComponent<EnemySearchControll>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = stoppingDistance;
            agent.speed = agentSpeed;
        }
        
        private void Update()
        {
            player = GameObject.FindGameObjectWithTag(searchControll.playerTag).transform;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            print(distanceToPlayer);

            if (distanceToPlayer <= detectionRange)
            {
                agent.SetDestination(townCentre.position);

                if (distanceToPlayer <= agent.stoppingDistance && !Cooldown)
                {
                    DamageDeal();
                    StartCoroutine(AttackCooldown());
                }
            }
            else
            {
                townCentre = GameObject.FindGameObjectWithTag(searchControll.targetTag).transform;
                agent.SetDestination(townCentre.position);
                print(townCentre);
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
