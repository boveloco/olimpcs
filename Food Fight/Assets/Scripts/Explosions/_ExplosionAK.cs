using UnityEngine;
using System.Collections;

public class _ExplosionAK : _ExplosionBase {

    private int damage = 10;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            coll.gameObject.SendMessage("ApplyDamage", damage);
        }
    }

    protected new void OnDestroy()
    {

    }
}
