using UnityEngine;
using System.Collections;

public class _Missile : _Weapon {

	public new int damage = 25;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//cria explosao
		Instantiate(obj, transform.position, Quaternion.identity);
		
		//toca audio
		if(audioS)
			audioS.PlayOneShot(audioExplosion, 1.0f);
		
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
		{
			//animacao dano
			ApplyDamage(damage);
		}

//		goToNext ();
		Destroy (gameObject);

	}

}
