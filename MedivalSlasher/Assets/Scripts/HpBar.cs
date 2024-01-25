using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour
{

    private float HP = 100f;
    public Image Bar;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.tag == "Enemy")
            {
            HP -= 5;
            Bar.fillAmount = HP / 100;
            }
    }
}
