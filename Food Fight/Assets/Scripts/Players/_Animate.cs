using UnityEngine;
using System.Collections;

public class _Animate : _PlayerAnimation {

    readonly string DAMAGE  = "__DAMAGE__";
    readonly string DEATH   = "__DEATH__";
    readonly string ATTACK  = "__ATTACK__";
    readonly string IDLE    = "__IDLE__";

    public void Animator(string type)
    {
        if (type == DAMAGE)
        {
            Damage();
            return;
        }
        if (type == DEATH)
        {
            SetDeath();
            return;
        }
        if (type == ATTACK)
        {
            ToAttack();
            return;
        }
        if (type == IDLE)
        {
            return;
        }
    }
    
}
