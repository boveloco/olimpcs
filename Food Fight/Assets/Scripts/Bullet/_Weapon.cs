using UnityEngine;
using System.Collections;

public class _Weapon : _Object {
    public int type = 0;
    public int damage = 10;

    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
            coll.gameObject.SendMessage("ApplyDamage", damage);

        GameObject.Find("TurnManager").GetComponent<_TurnController>().changeTurn();
        Destroy(gameObject);
    }

    

}
