using UnityEngine;
using System.Collections;

public class _Object : MonoBehaviour {

    public readonly string DAMAGE = "__DAMAGE__";
    public readonly string DEATH  = "__DEATH__";

    public int lives = 100;

    // Use this for initialization
    void Start() {
        if (this.lives == 0)
            this.lives = 100;
    }

    // Update is called once per frame
    void Update() {
    }

    public void ApplyDamage(int dmg)
    {
        lives -= dmg;
        if (lives <= 0)
            SendMessage("Del", this.gameObject);

        SendMessage("Animator", DAMAGE);
    }

    void Del(GameObject g)
    {
        SendMessage("Animator", DEATH);
        Destroy(g);
    }

}
