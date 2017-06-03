using Syrinj;
using UnityEngine;

class StateMachine
{

    private State currentState;

    private State lastState;

    public StateMachine()
    {

    }

    public void changeState(State s)
    { 
        if(currentState != null)
        {
            currentState.exit();
            lastState = currentState;
        }

        currentState = s;

        currentState.enter();

        Debug.Log(s);
    }

    public void update()
    {
        if(currentState!= null)
        {
            currentState.update();
        }
    }

    public State getCurrentState()
    {
        return currentState;
    }

}

