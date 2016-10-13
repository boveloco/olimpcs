using UnityEngine;
using System.Collections;

public class _Explosion_FF : MonoBehaviour {

    public GameObject obj;
    private void SetDestroy()
    {
        Destroy(obj.gameObject);
    }
}
