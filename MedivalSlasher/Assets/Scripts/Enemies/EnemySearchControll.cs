using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Enemies
{
    public class EnemySearchControll : MonoBehaviour
    {
        public static string playerTag = "Player";
        public static string targetTag = "Town Centre";

        public Transform target;

        public void Update()
        {
            if (target == null)
            {
                target = FindClosestObject(playerTag);
                if (target == null)
                {
                    target = FindClosestObject(targetTag);
                }
            }
        }

        Transform FindClosestObject(string tag)
        {
            GameObject closestObject = null;
            float closestDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                float distance = Vector3.Distance(obj.transform.position, currentPosition);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            if (closestObject != null)
            {
                return closestObject.transform;
            }
            else
            {
                return null;
            }
        }
    }
}
