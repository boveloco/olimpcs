﻿using UnityEngine;
using System.Collections;

public class _TiroAK : _Weapon {

    // Use this for initialization
    void Start()
    {
        damage = 10;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //cria explosao
        Instantiate(obj, transform.position, Quaternion.identity);

        //toca audio
        if (audioS)
            audioS.PlayOneShot(audioExplosion, 1.0f);

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            //animacao dano
            ApplyDamage(damage);
        }

        Destroy(gameObject);

    }

    protected new void OnDestroy()
    {
    }
}
