using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject menuPause;
    public GameObject menuWeapons;

    public GameObject Orange;
    public GameObject Green;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void clickPlay()
    {
        Time.timeScale = 1;
        Application.LoadLevel("stages_scene");
    }

    public void clickNight()
    {
        Time.timeScale = 1;
        Application.LoadLevel("noite_scene");
    }

    public void clickSand()
    {
        Time.timeScale = 1;
        Application.LoadLevel("sand_scene");
    }

    public void clickMenu()
    {
        Application.LoadLevel("menu_scene");
    }

    public void clickWeapons()
    {
        menuWeapons.SetActive(!menuWeapons.active);
    }

    public void clickPause()
    {
        Time.timeScale = (Time.timeScale -1) * -1;
        menuPause.SetActive(!menuPause.active);
    }

   
}
