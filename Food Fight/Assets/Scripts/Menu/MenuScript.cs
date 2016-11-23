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
    [HideInInspector]
    public bool menuAtivo;
    public bool start;
    
    // Use this for initialization
    void Start () {
        menuAtivo = false;
        start = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "menu_scene")
        {
            if (Input.GetButtonDown("START"))
            {
                clickPlay();
            }
        }

        if (SceneManager.GetActiveScene().name == "stages_scene")
        {
            if (Input.GetButtonDown("P1_X") || Input.GetButtonDown("P2_X"))
            {
                clickNight();
            }

            //if (Input.GetButtonDown("P1_O") || Input.GetButtonDown("P2_O"))
            //{
            //    clickSand();
            //}
        }

        if (SceneManager.GetActiveScene().name == "noite_scene")
        {
            if (Input.GetButtonDown("START"))
            {
                clickPause();
            }

            if (start)
            {
                if (Input.GetButtonDown("P1_/\\") || Input.GetButtonDown("P2_/\\"))
                {
                    clickNight();
                }

                if (Input.GetButtonDown("P1_O") || Input.GetButtonDown("P2_O"))
                {
                    clickMenu();
                }

                //if (Input.GetButtonDown("P1_[]") || Input.GetButtonDown("P2_[]"))
                //{
                //    clickPlay();
                //}

            }
        }

        if (SceneManager.GetActiveScene().name == "gameOverGreen_scene" || SceneManager.GetActiveScene().name == "gameOverOrange_scene")
        {
            if(Input.GetButtonDown("P1_X") || Input.GetButtonDown("P2_X"))
            {
                clickPlay();
            }

            if (Input.GetButtonDown("P1_O") || Input.GetButtonDown("P2_O"))
            {
                clickMenu();
            }
        }


    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
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
        // bazuka.Select();
        wait();
        menuAtivo = !menuAtivo;
    }

    public void clickPause()
    {
        Time.timeScale = (Time.timeScale -1) * -1;
        menuPause.SetActive(!menuPause.active);
        resume.Select();
        start = !start;
        wait();
        menuAtivo = !menuAtivo;
    }
}
