using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image slider;

    public void SetHealthValue(float health)
    {
        slider.fillAmount = health;
    }
}
