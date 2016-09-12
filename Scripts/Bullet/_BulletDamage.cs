using UnityEngine;
using System.Collections;

public class _BulletDamage : _Object
{

    public int live = 10;

    void Start()
    {
        if (live != 10)
            lives = live;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.gameObject.SendMessage("ApplyDamage", 10);
    }

}
