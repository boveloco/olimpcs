using UnityEngine;
using System.Collections;

public class _Weapon : _Object {
    public int type = 0;
    public int damage = 10;
    public GameObject obj;
    public AudioClip audioExplosion;
    public AudioSource audioS;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            coll.gameObject.SendMessage("ApplyDamage", damage);
            Instantiate(obj, transform.position, Quaternion.identity);
            audioS.PlayOneShot(audioExplosion, 1.0f);
        }
        else if(coll.gameObject.tag == "Ground")
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            audioS.PlayOneShot(audioExplosion, 1.0f);
        }

        Destroy(gameObject);
        GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
    }

    

}
