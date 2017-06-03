using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using Syrinj;

class Manager
{
    public static Manager instance = null;

    public static Manager getInstance()
    {
        if(instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }

    private Manager()
    {
        stateMachine = new StateMachine();
    }


    private StateMachine stateMachine;


    public void Update()
    {
        stateMachine.update();
    }

    public StateMachine getMachine()
    {
        return stateMachine;
    }
}

