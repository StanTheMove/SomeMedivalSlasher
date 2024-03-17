using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private Rigidbody rigidbody;
    public float torque;
    private string enemyTag;
    private bool doHit;

    public void TheEnemyTag (string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void ArrowFly (Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null); 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (doHit) return;
            doHit = true;
        if (collider.CompareTag(enemyTag))
        {
            var health = collider.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}
