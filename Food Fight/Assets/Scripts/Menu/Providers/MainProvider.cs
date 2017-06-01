using UnityEngine;
using System.Collections;
using Syrinj;

public class MainProvider : MonoBehaviour {

    [Provides]
    [Instance]
    private StateMachine stateMachine = Manager.getInstance().getMachine();

    [Provides]
    public string nextLevel; // set on editor

    [Provides]
    private State initialState = PlayingState.getInstance();

}
