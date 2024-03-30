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
        //private Transform townCentre;
        private Transform player;
        
        public Action OnPlayerRespawn;

        private EnemySearchControll searchControll;

        public float detectionRange = 10f;
        public float damageAmount = 10f;
        public float stoppingDistance = 2f;
        public float attackCooldown = 1f;
        private PlayerHealth gameEnd;

        private NavMeshAgent agent;
        private bool Cooldown = false;
        public float agentSpeed = 5f;

        private void Start()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            player = playerObject.transform;
            searchControll = GetComponent<EnemySearchControll>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = stoppingDistance;
            agent.speed = agentSpeed;
        }
        
        private void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (player == null)
            {
                if (gameEnd != null)
                {
                    gameEnd.HandlePlayerDeath();
                }
            }

            if (distanceToPlayer <= detectionRange)
            {
                agent.SetDestination(player.position);

                if (distanceToPlayer <= agent.stoppingDistance && !Cooldown)
                {
                    DamageDeal();
                    StartCoroutine(AttackCooldown());
                }
            }
            //else
            //{
            //    townCentre = GameObject.FindGameObjectWithTag(searchControll.targetTag).transform;
            //    agent.SetDestination(townCentre.position);
            //} 
        }

        public void SetPlayer(GameObject playerObject)
        {
            player = playerObject.transform;
        }

        public void DamageDeal()
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            //TownCentreHealth tcHealth = townCentre.GetComponent<TownCentreHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            //if (tcHealth != null)
            //{
            //    tcHealth.TakeDamage(damageAmount);
            //}
        }

        IEnumerator AttackCooldown()
        {
            Cooldown = true;
            yield return new WaitForSeconds(attackCooldown);
            Cooldown = false;
        }
    }
}
