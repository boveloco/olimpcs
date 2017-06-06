using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Syrinj;


class PausedState : State 
{
    private GameObject menuPause;

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
        Time.timeScale = 0;

    }

    public void exit()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;

    }

    public void update()
    {
    }

    public void setMenu(GameObject g)
    {
        this.menuPause = g;
    }
}

