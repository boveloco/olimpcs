using UnityEngine;
using System.Collections;

public class _PlayerAnimation : MonoBehaviour
{
    public float speed = 1.0f;
    public float forcesJump;
    public Transform ground;

    //spawna as bullets
    public Transform spawner;

    public int weapon;
    private bool isGround;

    private Animator anim;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        if(this.tag == "Player2")
            transform.eulerAngles = new Vector2(0, 180);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
        Moviment();
        ToCatchWeapon();
        //SetDeath();
    }

    private void Moviment()
    {
        isGround = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("Ground"));
        float x = Input.GetAxis("Horizontal");

        if (x > 0.0f)
        {
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetFloat("move1", Mathf.Abs(x));
            GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = true;
        }
        else if (x < 0.0f)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetFloat("move1", Mathf.Abs(x));
            GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = false;
        }

        if (isGround && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forcesJump);
        }

        anim.SetBool("jump1", !isGround);
    }

    private void ToCatchWeapon()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("weapon1", weapon);

            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("toAttack1", true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Q) && anim.GetInteger("weapon1") > -1)
        {
            anim.SetInteger("weapon1", -1);
            anim.SetBool("toKeepWeapon1", true);
        }
    }

    public void ToAttack()
    {
        if(anim.GetInteger("weapon1") > -1)
        {
            anim.SetBool("toAttack1", true);
        }
    }

    private void ToKeepWeapon()
    {
        anim.SetBool("toKeepWeapon1", false);
        anim.SetInteger("weapon1", -1);
    }

    private void FinishAttack()
    {
        anim.SetBool("toAttack1", false);
        anim.SetBool("finishPunch1", true);
        anim.SetBool("toKeepWeapon1", false);
        anim.SetBool("finishFing1", true);
        anim.SetInteger("weapon1", -1);
    }

    private void FinishAnimation()
    {
        anim.SetBool("finishPunch1", false);
        anim.SetBool("finishDanage1", false);
        anim.SetBool("toAttack1", false);
        anim.SetBool("finishPunch1", false);
        anim.SetBool("toKeepWeapon1", true);
        anim.SetBool("finishFing1", false);
        anim.SetInteger("weapon1", -1);
        anim.SetFloat("move1", 0.0f);
        anim.SetBool("jump1", false);
    }

    public void SetDeath()
    {
        anim.SetBool("death1", true);
    }

    public void Damage()
    {
        anim.SetBool("damage1", true);
    }

    private void FinishDamege()
    {
        anim.SetBool("damage1", false);
        anim.SetBool("finishDanage1", true);
    }

    private void SetDestroy()
    {
        transform.gameObject.SetActive(false);
    }

    private void shoot()
    {
        if (!GameObject.Find("TurnManager").GetComponent<_TurnController>().fire)
        {
            GameObject.Find("Weapons").GetComponent<_ControlWeapons>().instantiateWeapon(GetComponent<_Animate>().weapon, spawner);
            GameObject.Find("TurnManager").GetComponent<_TurnController>().fire = true;
        }
    }
}
