using Syrinj;

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

