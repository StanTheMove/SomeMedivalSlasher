using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int cost;
    public string itemName;

    private Shop shop;

    private void Start()
    {
        shop = GetComponentInParent<Shop>();
    }

    public void buy()
    {
        if (shop.money >= cost) 
        {
            shop.money -= cost;
            shop.addItem(itemName);
        }
    }
}
