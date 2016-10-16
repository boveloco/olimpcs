using UnityEngine;
using System.Collections;

public class _Granade : _Weapon {

	private float tim;
	private bool timFlag = false;
    protected int timeToExplode = 2;

	// Use this for initialization
	void Start () {
	    damage = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if (timFlag) {
			tim += Time.deltaTime;
		}
		if (tim >= timeToExplode) {
			tim = 0;
			timFlag = false;
			explode ();
		}
//		if(gotoNextFlag)
//			goToNext ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		timFlag = true;

	}

	void explode(){
		Instantiate(obj, transform.position, Quaternion.identity);
//		gotoNextFlag = true;
		Destroy (gameObject);
	}

	public void TriggerExplosion(GameObject coll){
		
	}
    protected new void OnDestroy()
    {
    }
}
