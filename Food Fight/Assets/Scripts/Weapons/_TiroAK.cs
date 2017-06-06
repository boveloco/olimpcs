using UnityEngine;
using System.Collections;

public class _TiroAK : _Weapon {

    // Use this for initialization
    void Start()
    {
        this.turn = FindObjectOfType<_TurnController>();
        damage = 10;
    }

	void OnDestroy(){
		// MANTENHA ESSA FUNÇÃO AQUI
		// ELA NULIFICA O ON DESTROY DO PAI!!
		//caralho quinta vez q essa merda some..kkkk
	}
}
