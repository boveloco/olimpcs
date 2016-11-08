using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject menuPause;
    public GameObject menuWeapons;
    public GameObject tutorial;

    public Button bazuka;
    public Button resume;
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "menu_scene")
        {
            if (Input.GetButtonDown("start"))
            {
                clickTutorial();
            }
        }

        if (SceneManager.GetActiveScene().name == "noite_scene")
        {
            if (Input.GetButtonDown("start"))
            {
                clickPause();
            }
        }
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
        bazuka.Select();
    }

    public void clickPause()
    {
        Time.timeScale = (Time.timeScale -1) * -1;
        menuPause.SetActive(!menuPause.active);
        resume.Select();
    }

    public void clickTutorial()
    {
        tutorial.SetActive(true);
    }

    public void playTutorial()
    {
        Application.LoadLevel("tutorial_scene");
    }
}
