using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public int money = 100;
    public TMP_Text moneyText;
    public TMP_Text inventory;

    public void addItem(string item)
    {
        moneyText.text = money.ToString();
        inventory.text += "\n" + item;
    }
}
