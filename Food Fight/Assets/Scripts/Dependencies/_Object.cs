using UnityEngine;
using System.Collections;

public class _Object : MonoBehaviour {

    public readonly string DAMAGE   = "__DAMAGE__";
    public readonly string DEATH    = "__DEATH__";
    public readonly string AK       = "__ATTACK__";
    public readonly string IDLE     = "__IDLE__";

    public int lives;

    // Use this for initialization
    void Start()
    {
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
    }

    private void verifyPosition()
    {
        if (transform.position.y < -4.0f )
        {
            Del();
            GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
            Destroy(this);
        }
        if(transform.position.x < -140f || transform.position.x > -104f)
        {
            GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
            Destroy(this);
        }
    }

    void Update()
    {
        verifyPosition();
    }
}
