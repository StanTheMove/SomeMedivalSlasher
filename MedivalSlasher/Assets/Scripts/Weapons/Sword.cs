using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Sword_DH;
    public int attackDamage = 5;
    public float attackRange = 1.0f;



    void Start()
    {
        
    }

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
