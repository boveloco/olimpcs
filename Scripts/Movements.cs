using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {

    public float speed = 1.0f;

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update() {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}

