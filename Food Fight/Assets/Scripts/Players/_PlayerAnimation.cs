using UnityEngine;
using System.Collections;
using Syrinj;

[RequireComponent(typeof(Animator))]
public class _PlayerAnimation : MonoBehaviour
{
    public float speed = 1.0f;
    public float forcesJump;
    public Transform ground;
    
    //spawna as bullets
    public Transform spawner;
        
    protected int weapon;

    [Inject]
    protected _TurnController turn;

    [Inject]
    public MenuScript menu;

    [Inject]
    public _WeaponMenu weapons;

    public AudioClip audioDeath;
    public AudioSource audioS;

    private bool isGround;

    private Animator anim;
    private Rigidbody2D rb;

    public int Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        weapon = -1;
        if(this.tag == "Player2")
            transform.eulerAngles = new Vector2(0, 180);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        FinishAnimation();
	}

	
	// Update is called once per frame
	void Update ()
    {
        atirar();
        
        Moviment();
        ToCatchWeapon();
        //SetDeath();
    }

    public void atirar()
    {
        var state = Manager.getInstance().getMachine().getCurrentState();
        if (gameObject.tag == "Player" && state is PlayingState)
        {
            
            if (Input.GetButtonDown("P1_[]") && weapon > -1)
            {
                if (weapon > 1)
                    ToAttack();
                else
                    shoot();
            }
        }

        if (gameObject.tag == "Player2" && state is PlayingState)
        {
            if (Input.GetButtonDown("P2_[]") && weapon > -1)
            {
                if (weapon > 1)
                    ToAttack();
                else
                    shoot();
            }
        }
    }


    private void Moviment()
    {
        isGround = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if (gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("SELECT1"))
            {
                Manager.getInstance().getMachine().changeState(WeaponState.getInstance());
            }

            //if (Input.GetButtonDown("P1_L1"))
            //{
            //    turn.flagTim = true;
            //}

            //if (Input.GetButtonDown("P1_R1"))
            //{
            //    turn.flagTim = true;
            //}

            if (Manager.getInstance().getMachine().getCurrentState() is PlayingState)
            {
                float x = Input.GetAxis("P1_Horizontal");
                float xT = Input.GetAxis("Horizontal");

                if (x > 0.9f || xT > 0.0)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    anim.SetBool("move", true);
                    GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = true;
                    //anim.SetInteger("weapon1", -1);
                    //anim.SetBool("toKeepWeapon1", true);
                }
                else if (x < -0.9f || xT < 0.0)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    anim.SetBool("move", true);
                    GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = false;
                    //anim.SetInteger("weapon1", -1);
                    //anim.SetBool("toKeepWeapon1", true);
                }
                else
                    anim.SetBool("move", false);

                if (isGround && (Input.GetButtonDown("P1_X")))
                {
                    rb.AddForce(Vector2.up * forcesJump);
                }
            }
            else if (Manager.getInstance().getMachine().getCurrentState() is WeaponState)
            {
                if (Input.GetButtonDown("P1_X"))
                {
                    weapons.setWeapon(0);
                }
                if (Input.GetButtonDown("P1_[]"))
                {
                    weapons.setWeapon(1);
                }
                if (Input.GetButtonDown("P1_/\\"))
                {
                    weapons.setWeapon(2);
                }
                if (Input.GetButtonDown("P1_O"))
                {
                    weapons.setWeapon(3);
                }
            }
        }

       

        if (gameObject.tag == "Player2")
        {
            if (Input.GetButtonDown("SELECT2"))
            {
                Manager.getInstance().getMachine().changeState(WeaponState.getInstance());
            }

            //if (Input.GetButtonDown("P2_L1"))
            //{
            //    turn.flagTim = true;
            //}

            //if (Input.GetButtonDown("P2_R1"))
            //{
            //    turn.flagTim = true;
            //}

            if (Manager.getInstance().getMachine().getCurrentState() is PlayingState)
            {
                float x = Input.GetAxis("P2_Horizontal");
                float xT = Input.GetAxis("Horizontal");

                if (x > 0.9f || xT > 0.0)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    anim.SetBool("move", true);
                    GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = true;
                    //anim.SetInteger("weapon1", -1);
                    //anim.SetBool("toKeepWeapon1", true);
                }
                else if (x < -0.9f || xT < 0.0)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    //anim.SetFloat("move1", Mathf.Abs(x));
                    anim.SetBool("move", true);
                    GameObject.Find("Weapons").GetComponent<_ControlWeapons>().side = false;
                    //anim.SetInteger("weapon1", -1);
                    //anim.SetBool("toKeepWeapon1", true);
                }
                else
                    anim.SetBool("move", false);

                if (isGround && (Input.GetButtonDown("P2_X")))
                {
                    rb.AddForce(Vector2.up * forcesJump);
                }
            }
            else if (Manager.getInstance().getMachine().getCurrentState() is WeaponState)
            {
                if (Input.GetButtonDown("P2_X"))
                {
                    weapons.setWeapon(0);
                }
                if (Input.GetButtonDown("P2_[]"))
                {
                    weapons.setWeapon(1);
                }
                if (Input.GetButtonDown("P2_/\\"))
                {
                    weapons.setWeapon(2);
                }
                if (Input.GetButtonDown("P2_O"))
                {
                    weapons.setWeapon(3);
                }
            }
        }

        //else
        //{
        //    ToCatchWeapon();
        //}
        

        anim.SetBool("jump1", !isGround);
    }

    private void ToCatchWeapon()
    {
        anim.SetInteger("weapon1", Weapon);
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
        if (anim)
        {
            anim.SetBool("toKeepWeapon1", false);
            anim.SetInteger("weapon1", -1);
        }
    }

    private void FinishAttack()
    {
        if (anim)
        {
            anim.SetBool("toAttack1", false);
            anim.SetBool("finishPunch1", true);
            anim.SetBool("toKeepWeapon1", false);
            anim.SetBool("finishFing1", true);
            //anim.SetInteger("weapon1", -1);
        }
    }

    public void FinishAnimation()
    {
        if (anim)
        {
            anim.SetBool("finishPunch1", false);
            anim.SetBool("finishDanage1", false);
            anim.SetBool("toAttack1", false);
            anim.SetBool("finishPunch1", false);
            anim.SetBool("toKeepWeapon1", true);
            anim.SetBool("finishFing1", false);
            //anim.SetInteger("weapon1", -1);
            anim.SetBool("move", false);
            anim.SetBool("jump1", false);
        }
    }

    public void SetDeath()
    {
        anim.SetBool("death1", true);
        audioS.PlayOneShot(audioDeath, 1.0f);
    }

    public void Damage()
    {   
        if(anim)
            anim.SetBool("damage1", true);
    }

    private void FinishDamege()
    {
        if (anim)
        {
            anim.SetBool("damage1", false);
            anim.SetBool("finishDanage1", true);
        }
    }

    private void SetDestroy()
    {
        transform.gameObject.SetActive(false);
    }

    private void shoot()
    {
        if (Manager.getInstance().getMachine().getCurrentState() is PlayingState)
        {
            GameObject.Find("Weapons").GetComponent<_ControlWeapons>().controlWeapons(GetComponent<_Animate>().Weapon, spawner);
            turn.fire = true;
            //FinishAnimation();
            //weapon = -1;
        }
    }
}
