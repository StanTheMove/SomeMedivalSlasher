using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherWeapon : MonoBehaviour
{
    public int weaponSelect = 0;

    void Start()
    {
        SelectedWeapon();
    }


    void Update()
    {
        int previousWeaponSelect = weaponSelect;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSelect >= transform.childCount - 1)
            {
                weaponSelect = 0;
            }
            else
            {
                weaponSelect++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSelect <= 0)
            {
                weaponSelect = transform.childCount - 1;
            }
            else
            {
                weaponSelect--;
            }
        }

        if (previousWeaponSelect != weaponSelect)
        {
            SelectedWeapon();
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform) 
        {
            if (i == weaponSelect)
            {
                weapon.gameObject.SetActive(true); 
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }  
    }
}
