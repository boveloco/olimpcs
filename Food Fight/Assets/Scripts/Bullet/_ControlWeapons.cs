using UnityEngine;
using System.Collections;

public class _ControlWeapons : MonoBehaviour {

    public GameObject missile;
    public GameObject granade;
    public int speed = 2;
    private GameObject[] types;
    public bool side = false;
    GameObject[] bulletInstances;

    void Start()
    {
        bulletInstances = new GameObject[10];
        types = new GameObject[3];
        types[0] = missile;
        types[1] = granade;
    }


    public void instantiateWeapon(int type, Transform t)
    {
            bulletInstances[0] = (GameObject)Instantiate(types[type], t.position + t.right, Quaternion.Euler(new Vector3(0, 0, 1)));
            bulletInstances[0].GetComponent<Rigidbody2D>().velocity = (speed * t.right);
            Rigidbody2D o = bulletInstances[0].GetComponent<Rigidbody2D>();
    }

    void Update()
    {}
}
