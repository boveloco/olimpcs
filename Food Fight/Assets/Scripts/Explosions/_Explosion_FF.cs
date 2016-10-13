using UnityEngine;
using System.Collections;

public class _Explosion : MonoBehaviour {

    public GameObject obj;
	private GameObject target;
    private void SetDestroy()
    {
        Destroy(obj.gameObject);
    }


}
