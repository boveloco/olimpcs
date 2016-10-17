using UnityEngine;
using System.Collections;

public class _WeaponMenu : MonoBehaviour {
    [HideInInspector]
    private static int MAX_WEAPON_SIZE = 4;
    private GameObject _target;
    private _PlayerAnimation _pAnim;

    public void setWeapon(int weapon)
    {
        if (weapon > MAX_WEAPON_SIZE)
            return;

        _target = GameObject.Find("TurnManager").GetComponent<_TurnController>().getPlayerOnTurn();
        _pAnim = _target.GetComponent<_PlayerAnimation>();
        _pAnim.Weapon = weapon;
    }

}
