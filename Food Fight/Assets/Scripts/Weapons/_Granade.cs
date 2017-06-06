using UnityEngine;
using System.Collections;

public class _Granade : _Weapon {

	private float tim;
	private bool timFlag = false;
    protected int timeToExplode = 2;

    public AudioClip audioExplosion;
    public AudioSource audioS;
    
    // Use this for initialization
    void Start () {
	    damage = 50;
        //audioS = GameObject.Find("Camera").GetComponent<AudioSource>() as AudioSource;
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

	new void OnCollisionEnter2D(Collision2D coll){
		timFlag = true;

	}

	void explode(){
		Instantiate(obj, transform.position, Quaternion.identity);
        if(audioS)
            audioS.PlayOneShot(audioExplosion, 1.0f);
        //		gotoNextFlag = true;
        Destroy (gameObject);
	}

	public void TriggerExplosion(GameObject coll){
		
	}
    protected new void OnDestroy()
    {
    }
}
