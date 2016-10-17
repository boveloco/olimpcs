using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class _ControlWeapons : MonoBehaviour {

    //full initiate
    private Transform _t;
    private int _type = 0;
    private int count = 0;
    private float timer = 0.0f;
    private int maxShots = 5;

    public List<GameObject> missiles;

    public GameObject missile;
    public GameObject granade;
    public GameObject dinamite;
    public GameObject ak;
    public int speed = 2;
    private GameObject[] types;
    public bool side = false;
    GameObject bulletInstance;

    private bool instantiate = false;
    void Start()
    {
        missiles = new List<GameObject>();
        bulletInstance = new GameObject();
        types = new GameObject[5];
        types[0] = missile;
        types[1] = ak;
        types[2] = dinamite;
        types[3] = granade;
    }

    void Update()
    {
        if (instantiate)
        {
            if (timer >= 0.25)
            {
                if (count >= maxShots)
                {
                    count = 0;
                    instantiate = false;
                    GameObject.Find("TurnManager").GetComponent<_TurnController>().flagTim = true;
                }
                timer = 0;

                bulletInstance = (GameObject)Instantiate(types[_type], _t.position + _t.right, _t.rotation);
                missiles.Add(bulletInstance);
                addForce(_t.right, 200);
                bulletInstance = null;
                count++;
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    public void controlWeapons(int type, Transform T) {
        switch (type) {
            case 0:
                instantiateWeapon(type, T);
                addForce(T.right, 250);
                break;
            case 1:
                instantiateManyWeapon(type, T);

                break;
            case 2:
                instantiateWeapon(type, T);
                break;
            case 3:
                instantiateWeapon(type, T);
                addForce((T.right + T.up), 250);
                break;
            default:
                return;
        }
    }

    private void instantiateManyWeapon(int type, Transform t)
    {
        _type = type;
        _t = t;
        instantiate = true;
        //if (bulletInstance)
        //    GameObject.Find("TurnManager").GetComponent<_TurnController>().camera.target = bulletInstance.transform;
    }

    private void instantiateWeapon(int type, Transform t)
    {
        bulletInstance = (GameObject)Instantiate(types[type], t.position + t.right, t.rotation);

        if (bulletInstance)
            GameObject.Find("TurnManager").GetComponent<_TurnController>().camera.target = bulletInstance.transform;
    }

	private void addVelocity(Transform t){
		bulletInstance.GetComponent<Rigidbody2D>().velocity = (speed * t.right);
	}

	private void addForce(Vector2 direction, float force){
		bulletInstance.GetComponent<Rigidbody2D> ().AddForce (direction * force);
	}


}
