using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Armor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI protectAmountText;
    private float protectAmount;

    private void Update()
    {
        protectAmountText.text = protectAmount.ToString();
    }

    public float CountDamage(float amount)
    {
        float endDamage = amount - (amount * (protectAmount / 100f)); 
        Mathf.Round(endDamage);
        return endDamage;
    }
}
