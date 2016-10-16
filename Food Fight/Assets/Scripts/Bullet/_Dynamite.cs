using UnityEngine;
using System.Collections;

public class _Dynamite : _Granade
{

    void Start()
    {
        timeToExplode = 5;

    }
    protected new void OnDestroy()
    {
    }

}
