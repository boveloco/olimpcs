using UnityEngine;
using System.Collections;

public class _Weapon : _Object {
    public int type = 0;
    public int damage = 10;
    public GameObject obj;
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            coll.gameObject.SendMessage("ApplyDamage", damage);
            Instantiate(obj, transform.position, Quaternion.identity);
        }
        else if(coll.gameObject.tag == "Ground")
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }

        GameObject.Find("TurnManager").GetComponent<_TurnController>().changeTurn();
        Destroy(gameObject);
    }

    

}
