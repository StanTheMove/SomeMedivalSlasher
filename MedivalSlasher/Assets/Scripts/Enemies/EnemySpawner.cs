using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform[] spawnPoints; 
    public float timeBetweenWaves = 5f; 
    public float timeBetweenEnemies = 1f; 
    public int numberOfEnemiesPerWave = 5;
    public int numberOfWaves = 3;
    public float agentSpeedIncreasePerWave = 0.2f;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        float currentAgentSpeed = enemyPrefab.GetComponent<NavMeshAgent>().speed;
        for (int wave = 0; wave < numberOfWaves; wave++)
        {
            enemyPrefab.GetComponent<NavMeshAgent>().speed = currentAgentSpeed + (wave * agentSpeedIncreasePerWave);

            for (int i = 0; i < numberOfEnemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
