using UnityEngine;
using System.Collections;
using Syrinj;

public class DarkNightProvider : MonoBehaviour {

    [Provides("Weapon")]
    public GameObject weaponMenu; //editor

    [Provides("Menu")]
    public GameObject pauseMenu; //editor

    [Provides]
    [FindObjectOfType(typeof(_WeaponMenu))]
    private _WeaponMenu weap;

    [Provides]
    [FindObjectOfType(typeof(MenuScript))]
    private MenuScript menu;

    [Provides]
    [FindObjectOfType(typeof(_TurnController))]
    private _TurnController turn; //assigned by editor

    [Provides]
    public string nextLevel; // set on editor

    private SingletonHub hub { get; set; }

    void Awake()
    {
        hub = SingletonHub.getInstance();
        WeaponState.getInstance().setWeapon(weaponMenu);
        PausedState.getInstance().setMenu(pauseMenu);
    }

}
