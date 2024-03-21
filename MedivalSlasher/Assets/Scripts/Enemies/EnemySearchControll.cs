using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

namespace Enemies
{
    public class EnemySearchControll : MonoBehaviour
    {
        public string playerTag = "Player";
        public string targetTag = "Town Centre";

        public Transform FindClosestObject(string tag)
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
