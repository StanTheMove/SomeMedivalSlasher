using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Enemies;
using Player;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(EnemyAttacker))]
public class EnemyNavigationController : MonoBehaviour
{
    private PlayerMovement movement;
    private EnemyAttacker enmyComponent;

    [SerializeField] private float maxDistance = 100f;
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        enmyComponent = GetComponent<EnemyAttacker>();
    }

    private void Update()
    {
        
    }
}
