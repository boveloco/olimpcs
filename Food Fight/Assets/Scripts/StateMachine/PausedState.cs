using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Syrinj;


class PausedState : State 
{
    public GameObject menuPause;

    public static PausedState instance;

    public static PausedState getInstance()
    {
        if(instance == null)
        {
            instance = new PausedState();
        }

        return instance;
    }

    public void enter()
    {
        menuPause.SetActive(true);
    }

    public void exit()
    {
        menuPause.SetActive(false);
    }

    public void update()
    {
        Time.timeScale = (Time.timeScale - 1) * -1;
        wait();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void setMenu(GameObject g)
    {
        this.menuPause = g;
    }
}

