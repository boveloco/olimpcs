using UnityEngine;
using System.Collections;

public class _Gloves : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.H)) {
			player = GameObject.Find ("TurnManager").GetComponent<_TurnController> ().getPlayerOnTurn ();
			transform.position = player.GetComponent<Transform> ().position;
			addForce ();
		}
	}

	void addForce(){
		player.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 400);
	}
    protected new void OnDestroy()
    {
    }
}
