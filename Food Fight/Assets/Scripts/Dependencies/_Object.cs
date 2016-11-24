using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Object : MonoBehaviour {

    public readonly string DAMAGE   = "__DAMAGE__";
    public readonly string DEATH    = "__DEATH__";
    public readonly string AK       = "__ATTACK__";
    public readonly string IDLE     = "__IDLE__";

    public Image health;

    public GameObject focus;

    public int lives;
	private int map;
    // Use this for initialization
    void Start()
    {
		map = GameObject.Find ("TurnManager").GetComponent<_TurnController> ().map;
    }

    public void ApplyDamage(int dmg)
    {
        lives -= dmg;
        if (lives <= 0)
            gameObject.GetComponent<_Animate>().Animator(DEATH);

        gameObject.GetComponent<_Animate>().Animator(DAMAGE);
    }

    private void verifyPosition()
    {
		if (map == 1) {
			if (transform.position.y < -4.0f || transform.position.x < -140f || transform.position.x > -104f ) {
				this.gameObject.SetActive (false);
				GameObject.Find ("TurnManager").GetComponent<_TurnController> ().flagTim = true;
			}
		}
    }

    void Update()
    {
        if (gameObject.GetComponent<_PlayerAnimation>().enabled)
            focus.SetActive(true);
        else
            focus.SetActive(false);


        health.fillAmount = (float)lives / 100;

        verifyPosition();
    }
}
