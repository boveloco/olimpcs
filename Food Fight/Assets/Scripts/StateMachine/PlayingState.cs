using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PlayingState : State
{
    public static PlayingState instance = null;
    
    public static PlayingState getInstance()
    {
        if(instance == null)
        {
            instance = new PlayingState();
        }
        return instance;
    }

    public void enter()
    {

    }

    public void exit()
    {

    }

    public void update()
    {

    }
}

