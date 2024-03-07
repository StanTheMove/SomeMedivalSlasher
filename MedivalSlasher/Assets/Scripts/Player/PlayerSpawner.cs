using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using System;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public GameObject Player;
    public Action OnPlayerRespawn;
    
    void Awake()
    {
        SpawnCharacter();
    }

    void SpawnCharacter()
    {
        GameObject spawnObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        OnPlayerRespawn?.Invoke();
        spawnObject.transform.parent = transform;
        Player = spawnObject;
        Player.GetComponent<PlayerHealth>().OnPlayerDeath += SpawnCharacter;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in Enemies)
        {
            enemy.GetComponent<EnemyNavigationController>().player = Player.transform;
        }
    }
}
