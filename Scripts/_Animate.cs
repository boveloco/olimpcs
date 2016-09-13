using UnityEngine;
using System.Collections;

public class _Animate : _AnimacaoAlisson {

    readonly string DAMAGE  = "__DAMAGE__";
    readonly string DEATH   = "__DEATH__";
    readonly string AK      = "__ATTACK__";
    readonly string IDLE    = "__IDLE__";

    void Animator(string type)
    {
        if (type == DAMAGE)
            return;
    }
}
