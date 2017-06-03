using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Syrinj;

class WeaponState : State
{

    private GameObject weaponMenu;

    public static WeaponState instance;

    public static WeaponState getInstance()
    {
        if(instance == null)
        {
            instance = new WeaponState();
        }
        return instance;
    }

    private WeaponState()
    {
    }

    public void enter()
    {
        weaponMenu.SetActive(true);
    }

    public void exit()
    {
        weaponMenu.SetActive(false);
    }

    public void update()
    {
        wait();

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void setWeapon(GameObject g)
    {
        weaponMenu = g;
    }
}

