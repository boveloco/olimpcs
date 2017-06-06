using UnityEngine;
using System.Collections;

public class _Dynamite : _Granade
{

    void Start()
    {
        this.turn = FindObjectOfType<_TurnController>();
        timeToExplode = 5;
        damage = 80;

    }
    protected new void OnDestroy()
    {
    }

}
