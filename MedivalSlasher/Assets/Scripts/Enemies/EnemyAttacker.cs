using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] static public string playerTag = "Player";
        [SerializeField] static public string targetTag = "Town Centre";

        public GameObject player;
        public GameObject target;

        bool cantFindPlayer;
        public virtual void Awake()
        {
            player = GameObject.FindGameObjectWithTag(playerTag);

            if(cantFindPlayer)
            {
                target = GameObject.FindGameObjectWithTag(targetTag);
            }
        }
    }
}
