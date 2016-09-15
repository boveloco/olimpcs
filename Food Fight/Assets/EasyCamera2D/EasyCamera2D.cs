using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace EasyCamera2D
{
    [RequireComponent(typeof(Camera))]
    public class EasyCamera2D : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        public float shakeDuration, shakeStrenght;

        public float speed;

        public List<EasyAnchor> myAnchors = new List<EasyAnchor>();

        IEnumerator ScreenShake()
        {
            float t = shakeDuration;

            do
            {
                t -= Time.deltaTime;

                Vector2 shake = Random.insideUnitCircle * shakeStrenght;

                shake.x += transform.position.x;
                shake.y += transform.position.y;

                transform.localPosition = shake;
                transform.position = new Vector3(transform.position.x, transform.position.y, offset.z);

                yield return new WaitForEndOfFrame();
            } while (t >= 0);

            yield return null;
        }

        public void Shake()
        {
            StartCoroutine(ScreenShake());
        }

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ScreenShake());
            }
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                GetComponent<Camera>().orthographicSize += 1 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.KeypadMinus))
            {
                GetComponent<Camera>().orthographicSize -= 1 * Time.deltaTime;
            }
        }

        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
        }
    }
}