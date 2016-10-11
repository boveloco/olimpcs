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


    public bool fire = false;

    //false = orange
    private bool team = false;

    private int turn    = 0;
    private int turn2   = 0;

    private float timeLeft = 30;

    // timer
    private float tim = 0.0f;
    public bool flagTim = false;
    // Use this for initialization
    void Start () {
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
		verifyEnd();
        setTimer();

        if(flagTim)
            tim += Time.deltaTime;

        if (getTim(0.7f))
            changeTurn();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            flagTim = true;
            
        }
	}

    private void toogleObjectTransform(GameObject objecto, bool activate)
    {
        foreach (GameObject o in objects)
        {
            o.GetComponent<_PlayerAnimation>().FinishAnimation();
            o.GetComponent<_PlayerAnimation>().enabled = false;
            if (!o.activeSelf)
            {
                objects.Remove(o);
				toogleObjectTransform (objecto, activate);
                return;
            }

        }
        foreach (GameObject p in objects2)
        {
            p.GetComponent<_PlayerAnimation>().FinishAnimation();
            p.GetComponent<_PlayerAnimation>().enabled = false;
            if (!p.activeSelf)
            {
                objects2.Remove(p);
				toogleObjectTransform (objecto, activate);
                return;
            }

        }
		objecto.GetComponent<_PlayerAnimation> ().enabled = true;
        if(objecto.transform)
		    camera.target = objecto.transform;
		return;
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
            if (turn >= objects.Count -1)
            {
                turn = 0;
                return;
            }
        } else {
            if (turn2 >= objects2.Count -1)
            {
                turn2 = 0;
                return;
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
            flagTim = true;
            timeLeft = 30;
            //changeTurn();
        }
        else
            timeLeft -= Time.deltaTime;

        timer.text = ((int)timeLeft).ToString();
    }

    public void changeTurn()
    {
        Debug.Log(tim);
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
        if (team)
        {
			Green.SetActive(true);
			Orange.SetActive(false);
        }
        else
        {
			Green.SetActive(false);
			Orange.SetActive(true);
        }
    }

	public void verifyEnd(){
		if (objects.Count == 0) {
			team = true;
			endGame ();
		} else if(objects2.Count == 0){
			team = false;
			endGame();
		}
	}

    bool getTim(float timer)
    {
        if (tim >= timer)
        {
            flagTim = !flagTim;
            tim = 0f;
            return true;
        }

        return false;
    }

}
