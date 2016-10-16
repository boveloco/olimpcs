using UnityEngine;
using System.Collections;

public class _ExplosionDinamyte : _ExplosionBase {

        private int damage = 60;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
            coll.gameObject.SendMessage("ApplyDamage", damage);
    }
}
