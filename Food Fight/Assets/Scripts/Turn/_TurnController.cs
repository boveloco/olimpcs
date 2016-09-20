using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _TurnController : MonoBehaviour {

    public EasyCamera2D.EasyCamera2D camera;

    public Text timer;

    private GameObject[] objects;
    private GameObject[] objects2;

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

        objects = GameObject.FindGameObjectsWithTag("Player");
        objects2 = GameObject.FindGameObjectsWithTag("Player2");
        lastTurn = objects.Length -1;
        lastTurn2 = objects2.Length -1;

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
        foreach (GameObject o in objects)
        {
            if (o.activeSelf)
            {
                active1 = true;
                break;
            }
        }
        foreach (GameObject o in objects2)
        {
            if (o.activeSelf)
            {
                active2 = true;
                break;
            }
        }
        if(active1 && active2)
        {
            if (team)
            {
                if (objects[turn].activeSelf)
                {
                    lastTurn = turn;

                    if (turn >= objects.Length)
                    {
                        turn = 0;
                    }
                } else {
                
                    if (turn < objects.Length -1)
                        turn++;
                    else
                        turn = 0;
                    controlObjects();
                }
            } else {
                if (objects2[turn2].activeSelf)
                {
                    lastTurn2 = turn2;
                    if (turn2 >= objects2.Length)
                    {
                        turn2 = 0;
                    }
                } else {
                    if (turn2 < objects2.Length -1)
                        turn2++;
                    else
                        turn2 = 0;
                    controlObjects();
                }
            }
        } else
        {
            endGame();
        }
        if (team)
            turn++;
        else
            turn2++;
        active1 = active2 = false;
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
        else
        {
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
