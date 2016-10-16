using UnityEngine;
using System.Collections;

public class _WeaponMenu : MonoBehaviour {

    public int weapon = 0;
    private static int MAX_WEAPON_SIZE = 4;
    private GameObject _target;

    public void setWeapon(int weapon)
    {
        if (weapon > MAX_WEAPON_SIZE)
            return;

        _target = GameObject.Find("TurnManager").GetComponent<_TurnController>().getPlayerOnTurn();
        _target.GetComponent<_Animate>().weapon = weapon;
    }

}
