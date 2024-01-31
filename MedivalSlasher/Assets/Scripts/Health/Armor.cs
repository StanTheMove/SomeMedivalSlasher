using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    private float protectAmount;

    public float CountDamage(float amount)
    {
        float endDamage = amount - (amount * (protectAmount / 100f)); 
        Mathf.Round(endDamage);

        return endDamage;
    }
}
