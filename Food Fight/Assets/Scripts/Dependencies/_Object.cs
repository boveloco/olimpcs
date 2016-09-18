using UnityEngine;
using System.Collections;

public class _Object : MonoBehaviour {

    public readonly string DAMAGE   = "__DAMAGE__";
    public readonly string DEATH    = "__DEATH__";
    public readonly string AK       = "__ATTACK__";
    public readonly string IDLE     = "__IDLE__";

    public int lives = 100;

    // Use this for initialization
    void Start() {
        if (this.lives == 0)
            this.lives = 100;
    }

    void Update()
    {
        //verifyPosition();
    }

    public void ApplyDamage(int dmg)
    {
        lives -= dmg;
        if (lives <= 0)
            SendMessage("Del");

        SendMessage("Animator", DAMAGE);
    }

    void Del()
    {
        SendMessage("Animator", DEATH);
        Destroy(gameObject);
    }

    private void verifyPosition()
    {
        if (transform.position.y < -4.0f )
        {
            Del();
            GameObject.Find("TuntMananger").GetComponent<_TurnController>().changeTurn();
        }
    }

}
