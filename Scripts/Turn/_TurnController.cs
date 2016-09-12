using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _TurnController : MonoBehaviour {


    public Text timer;
    private GameObject[] objects;

    private int lastTurn;
    private int turn = 0;

    private float timeLeft = 30;

	// Use this for initialization
	void Start () {

        objects = GameObject.FindGameObjectsWithTag("Player");
        lastTurn = objects.Length;

        foreach (GameObject o in objects)
        {
            o.GetComponent<Movements>().enabled = false;
        }

        changeTurn();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeTurn();
        }

        setTimer();
	    }

    private GameObject toogleObjectTransform(GameObject objecto, bool activate)
    {
        objecto.GetComponent<Movements>().enabled = activate;
        return objects[turn];
    }

    private _TurnController controlObjects()
    {
        lastTurn = turn;

        if (objects.Length - 1 > turn)
            turn++;
        else
            turn = 0;

        return this;
    }

    private void setTimer()
    {
        if (timeLeft < 0)
        {
            timeLeft = 30;
            changeTurn();
        }
        else
            timeLeft -= Time.deltaTime;

        timer.text = timeLeft.ToString();
    }

    private void changeTurn()
    {
        controlObjects();
        toogleObjectTransform(objects[lastTurn], false);
        toogleObjectTransform(objects[turn], true);
    }

}
