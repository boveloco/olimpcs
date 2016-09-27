using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class _TurnController : MonoBehaviour {

    public EasyCamera2D.EasyCamera2D camera;

    public Text timer;

    private List<GameObject> objects;
    private List<GameObject> objects2;

    public GameObject Orange;
    public GameObject Green;

    private bool active1;
    private bool active2;

    public bool fire = false;

    //false = orange
    private bool team = false;

    private int lastTurn;
    private int lastTurn2;
    private int turn    = 0;
    private int turn2   = 0;

    private float timeLeft = 30;

	// Use this for initialization
	void Start () {
        active1 = active2 = false;
        objects = new List<GameObject>();
        objects2 = new List<GameObject>();

        GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in go)
        {
            objects.Add(g);
        }
        go = GameObject.FindGameObjectsWithTag("Player2");
        foreach (GameObject g in go)
        {
            objects2.Add(g);
        }
        lastTurn = objects.Count -1;
        lastTurn2 = objects2.Count -1;

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
	}

    private void toogleObjectTransform(GameObject objecto, bool activate)
    {
        foreach (GameObject o in objects)
        {
            o.GetComponent<_PlayerAnimation>().enabled = false;
            if (!o.activeSelf)
            {
                objects.Remove(o);
                return;
            }

        }
        foreach (GameObject p in objects2)
        {
            p.GetComponent<_PlayerAnimation>().enabled = false;
            if (!p.activeSelf)
            {
                objects2.Remove(p);
                return;
            }

        }

        if (team)
        {
            //controla a camera
            camera.target = objects[turn].transform;

            objecto.GetComponent<_PlayerAnimation>().enabled = activate;
        } else {
            //controla a camera
            camera.target = objects2[turn2].transform;

            objecto.GetComponent<_PlayerAnimation>().enabled = activate;
        }
    }

    private void controlObjects()
    {
        if(turn >= objects.Count - 1)
        {
            turn = objects.Count - 1;
        }

        if (turn2 >= objects2.Count - 1)
        {
            turn2 = objects2.Count - 1;
        }

        if (team)
        {
            if (objects[turn].activeSelf)
            {
                lastTurn = turn;

                if (turn >= objects.Count -1)
                {
                    turn = 0;
                    return;
                }
            }
        } else {

            if (objects2[turn2].activeSelf)
            {
                lastTurn2 = turn2;
                if (turn2 >= objects2.Count -1)
                {
                    turn2 = 0;
                    return;
                }
            }
                
        }

        if (team)
            turn++;
        else
            turn2++;
        return;

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
            toogleObjectTransform(objects[turn], true);
            controlObjects();
            team = !team;
        }
        else
        {
            timeLeft = 30;
            toogleObjectTransform(objects2[turn2], true);
            controlObjects();
            team = !team;
        }
        if (fire)
            fire = !fire;
    }

    public void toogleFire()
    {
       fire = !fire;
    }

    public void endGame()
    {
        if (!active1)
        {
            Green.SetActive(false);
            Orange.SetActive(true);
        }
        if (!active2)
        {
            Orange.SetActive(false);
            Green.SetActive(true);
        }
    }

}
