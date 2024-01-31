using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : MonoBehaviour
{
    public Transform Enemy;
    public GameObject Sword_DH;
    public int attackDamage = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwordSwing());
        }
    }

    IEnumerator SwordSwing()
    { 
    Sword_DH.GetComponent<Animator>().Play("SwordSwing");
    yield return new WaitForSeconds(1.0f);
    Sword_DH.GetComponent<Animator>().Play("New State");
    }
}
