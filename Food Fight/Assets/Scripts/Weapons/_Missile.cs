using UnityEngine;
using System.Collections;
using Syrinj;
public class _Missile : _Weapon {

	// Use this for initialization
	void Start () {
        this.turn = FindObjectOfType<_TurnController>();
        damage = 25;
	}
}
