using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _TurnController : MonoBehaviour {

    public EasyCamera2D.EasyCamera2D camera;

    public Text timer;
    private GameObject[] objects;
    private GameObject[] objects2;

    public bool fire = false;

    private bool team = false;

    private int lastTurn;
    private int lastTurn2;
    private int turn    = 0;
    private int turn2   = 0;

    private float timeLeft = 30;

	// Use this for initialization
	void Start () {

        objects = GameObject.FindGameObjectsWithTag("Player");
        objects2 = GameObject.FindGameObjectsWithTag("Player2");
        lastTurn = objects.Length;
        lastTurn2 = objects2.Length;

        foreach (GameObject o in objects)
        {
            o.GetComponent<_PlayerAnimation>().enabled = false;
        }
        foreach (GameObject p in objects2)
        {
            p.GetComponent<_PlayerAnimation>().enabled = false;
        }

        changeTurn();
    }

    // Update is called once per frame
    void Update() {

        setTimer();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeTurn();
        }
        //finaliza o game caso nao tenha mais players
        if (objects.Length < 1)
        {

        }
        if (objects2.Length < 1)
        {
            
        }
	    }

    private GameObject toogleObjectTransform(GameObject objecto, bool activate)
    {
        foreach (GameObject o in objects)
        {
            o.GetComponent<_PlayerAnimation>().enabled = false;
        }
        foreach (GameObject p in objects2)
        {
            p.GetComponent<_PlayerAnimation>().enabled = false;
        }

        if (team)
        {
            //controla a camera
            camera.target = objects[turn].transform;

            objecto.GetComponent<_PlayerAnimation>().enabled = activate;
            return objects[turn];
        } else {
            //controla a camera
            camera.target = objects2[turn2].transform;

            objecto.GetComponent<_PlayerAnimation>().enabled = activate;
            return objects2[turn2];
        }
    }

    private _TurnController controlObjects()
    {
        if (team)
        {
            lastTurn = turn;

            if (objects.Length - 1 > turn)
                turn++;
            else
                turn = 0;
            return this;
        } else {

            lastTurn2 = turn2;
            if (objects2.Length - 1 > turn2)
                turn2++;
            else
                turn2 = 0;
            return this;
        }
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

        timer.text = ((int)timeLeft).ToString();
    }

    public void changeTurn()
    {
        if (team)
        {
            timeLeft = 30;
            controlObjects();
            toogleObjectTransform(objects[turn], true);
            team = !team;
        }
        else {
            timeLeft = 30;
            controlObjects();
            toogleObjectTransform(objects2[turn2], true);
            team = !team;
        }
        if (fire)
            fire = !fire;
    }

    public void toogleFire()
    {
       fire = !fire;
    }

}
