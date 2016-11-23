using UnityEngine;
using System.Collections;

public class _Focus : MonoBehaviour {

    private RectTransform rect;
    private float y;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
        y = rect.anchoredPosition.y;
        
        gameObject.SetActive(false);

        InvokeRepeating("Position", 0, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
       rect.anchoredPosition = new Vector2(0, y);
    }

    void Position()
    {
        if (rect.anchoredPosition.y == 0.3f)
            y = 0.15f;
        if (rect.anchoredPosition.y == 0.15f)
            y = 0.0f;
        if (rect.anchoredPosition.y == 0.0f)
            y = -0.1f;
        if (rect.anchoredPosition.y == -0.1f)
            y = 0.14f;
        if (rect.anchoredPosition.y == 0.14f)
            y = 0.3f;
    }
}
