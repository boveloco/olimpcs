using UnityEngine;
using System.Collections;

public class _Weapon : MonoBehaviour {
    protected int damage = 0;
    public GameObject obj;

    void Start()
    {
        damage = 10;
    }

    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        //cria explosao
        Instantiate(obj, transform.position, Quaternion.identity);


        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            //animacao dano
            coll.gameObject.GetComponent<_Object>().ApplyDamage(damage);
        }

        //		goToNext ();
        Destroy(gameObject);
    }
   

    protected void OnDestroy()
    {
        GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
    }

    protected void verifyPosition()
    {
        if (transform.position.y < -4.0f)
        {
            GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
            Destroy(this);
        }
        if (transform.position.x < -140f || transform.position.x > -104f)
        {
            GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
            Destroy(this);
        }
    }

    protected void Update()
    {
        verifyPosition();
    }

}
