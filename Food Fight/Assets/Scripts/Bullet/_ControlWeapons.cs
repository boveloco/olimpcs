using UnityEngine;
using System.Collections;

public class _ControlWeapons : MonoBehaviour {

    public GameObject missile;
    public GameObject granade;
	public GameObject machinegun;
    public int speed = 2;
    private GameObject[] types;
    public bool side = false;
    GameObject bulletInstance;

    void Start()
    {
		bulletInstance = new GameObject();
        types = new GameObject[3];
        types[0] = missile;
        types[1] = granade;
		types[2] = machinegun;
    }


	public void controlWeapons(int type, Transform T){
		switch (type) {
		case 0:
			instantiateWeapon (type, T);
			//addVelocity (T);
			addForce(T.right, 250);
			break;
		case 1: 
			instantiateWeapon (type, T);
			addForce((T.right + T.up), 250);
			break;
		default:
			return;
		}
	}

    private void instantiateWeapon(int type, Transform t)
    {
            bulletInstance = (GameObject)Instantiate(types[type], t.position + t.right, t.rotation);
            
            if(bulletInstance)
                GameObject.Find("TurnManager").GetComponent<_TurnController>().camera.target = bulletInstance.transform;
    }
	private void addVelocity(Transform t){
		bulletInstance.GetComponent<Rigidbody2D>().velocity = (speed * t.right);
	}

	private void addForce(Vector2 direction, float force){
		bulletInstance.GetComponent<Rigidbody2D> ().AddForce (direction * force);
	}

	void Update()
    {}
}
