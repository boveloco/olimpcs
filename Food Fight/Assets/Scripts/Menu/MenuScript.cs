using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public GameObject menuPause;
    public GameObject menuWeapons;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void clickPlay()
    {
        Time.timeScale = 1;
        Application.LoadLevel("noite_scene");
    }

    public void clickMenu()
    {
        Application.LoadLevel("menu_scene");
    }

    public void clickPause()
    {
        Time.timeScale = (Time.timeScale -1) * -1;
        menuPause.SetActive(!menuPause.active);
    }

    public void clickWeaponsMenu()
    {
        menuPause.SetActive(!menuWeapons.active);
    }
}
