using UnityEngine;
using System.Collections;

public class PlayersBehaviour : MonoBehaviour {

    public float speed;
    public float speedMax;
    public float force;
    public Transform ground;
    //public GameObject spaw;
    private Animator anim;
    private Rigidbody2D rgbd2;
    private bool isGround;
    private bool weapon;

    public int jumpPower;
    // Use this for initialization
    void Start () {
        rgbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        weapon = false;

        if(tag == "Player2")
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
	}
	
	// Update is called once per frame
	void Update () {
        /* if(Input.GetAxis("Horizontal") < 0)
         {
             transform.Translate(Vector2.left * Time.deltaTime * speed);
         }
         if (Input.GetAxis("Horizontal") > 0)
         {
             transform.Translate(Vector2.right * Time.deltaTime * speed);
         }

         if(Input.GetKey(KeyCode.Space))
         {
             GetComponent<Rigidbody2D>().velocity = new Vector3(0, force * Time.deltaTime, 0);
             //transform.Translate(Vector2.up * Time.deltaTime * force);
         }*/

        Moviment();
    }

    private void Moviment()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        
        Vector2 move = new Vector2(x, 0);

        isGround = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!weapon)
        {
            if (x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }

            if (x > 0)
            {
                if (rgbd2.velocity.x < speedMax)
                {
                    rgbd2.AddForce(new Vector2(x, 0), ForceMode2D.Impulse);
                }
                else
                {
                    rgbd2.velocity.Set(speedMax, rgbd2.velocity.y);
                }
            }
            else if (x < 0)
            {
                if (rgbd2.velocity.x > -speedMax)
                {
                    rgbd2.AddForce(new Vector2(x, 0), ForceMode2D.Impulse);
                }
                else
                {
                    rgbd2.velocity.Set(-speedMax, rgbd2.velocity.y);
                }
            }



        }
        //Animação
        anim.SetFloat("move", Mathf.Abs(x));

        Jump();
        Shot();
    }

    private void Jump()
    {
        if(!weapon && isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rgbd2.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //rgbd2.velocity = new Vector3(0, force * Time.deltaTime, 0);
        }

        anim.SetBool("jump", !isGround);
    }

    private void Shot()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            weapon = true;
        }
        else
        {
            weapon = false;
        }

        if(weapon)
        {
            float y = Input.GetAxis("Vertical") * 5;

            float toRadians = (15.0f * Mathf.PI) / 180;
            transform.Rotate(new Vector3(0, 0, 10 * y * Time.deltaTime));
            
            if (transform.rotation.z > toRadians)
            {
                transform.Rotate(new Vector3(0, 0, transform.rotation.z - toRadians));
                Debug.Log("..........");
            }
            else if (transform.rotation.z < -toRadians)
                transform.Rotate(new Vector3(0, 0, -toRadians));
            

        }
        else
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - transform.rotation.z));
        }

        anim.SetBool("bazooka", weapon);
    }
}
