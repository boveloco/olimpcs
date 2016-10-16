using UnityEngine;
using System.Collections;

public class _ExplosionBase : MonoBehaviour
{
    protected void OnDestroy()
    {
        GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
    }
}
