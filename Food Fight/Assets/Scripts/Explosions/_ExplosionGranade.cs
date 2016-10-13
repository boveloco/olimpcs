using UnityEngine;
using System.Collections;

public class _ExplosionGranade : _Explosion_FF {

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2") {
			coll.gameObject.SendMessage ("ApplyDamage", 50);
			GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
		}
	}
}
