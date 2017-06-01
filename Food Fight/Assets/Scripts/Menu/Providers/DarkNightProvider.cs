using UnityEngine;
using System.Collections;
using Syrinj;

public class DarkNightProvider : MonoBehaviour {


    [Provides]
    public GameObject menuWeapons; // at editor

    [Provides]
    public _TurnController turn; //assigned by editor

    [Provides]
    public string nextLevel; // set on editor
    

}
