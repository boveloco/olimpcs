using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class _TurnController : MonoBehaviour {

    public new EasyCamera2D.EasyCamera2D camera;

    public Text timer;

    private List<GameObject> objects; //Laranja
    private List<GameObject> objects2; //Verde

    public GameObject Orange;
    public GameObject Green;


    public bool fire = false;

    //false = green
    [HideInInspector]
    public bool team = false;

    private int turn = 0;
    private int turn2 = 0;

    private float timeLeft = 31;

    // timer
    private float tim = 0.0f;
    public bool flagTim = false;

    // Use this for initialization
    void Start() {


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

        if (flagTim)
            tim += Time.deltaTime;

        if (getTim(0.7f))
            changeTurn();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            flagTim = true;
        }

    }

    private void toogleObjectTransform(GameObject objecto, bool activate)
    {
        objecto.GetComponent<_PlayerAnimation>().enabled = true;
        if (objecto.transform)
            camera.target = objecto.transform;
        return;
    }

    private void controlObjects()
    {
        if (team)
        {
            if (turn >= objects.Count)
            {
                turn = 0;
            }
			turn++;
        } else {
            if (turn2 >= objects2.Count)
            {
                turn2 = 0;
            }
			turn2++;
        }
    }

    private void setTimer()
    {
        if (timeLeft < 0)
        {
            flagTim = true;
            timeLeft = 31;
            //changeTurn();
        }
        else
            timeLeft -= Time.deltaTime;

        timer.text = ((int)timeLeft).ToString();
    }

	/**
		verifica se ainda esta ativo, finaliza as animacoe e seta o player como parado.
	*/
	public void checkActivated() {
		List<GameObject> toDelete = new List<GameObject>();

		foreach (GameObject o in objects)
        {
            if (!o.activeSelf)
            {
				toDelete.Add(o);
            }
            o.GetComponent<_PlayerAnimation>().FinishAnimation();
            o.GetComponent<_PlayerAnimation>().enabled = false;
        }
		foreach (GameObject o in toDelete) {
			objects.Remove (o);
		}
		toDelete.Clear ();
        foreach (GameObject p in objects2)
        {
            if (!p.activeSelf)
            {
				toDelete.Add(p);
            }
            p.GetComponent<_PlayerAnimation>().FinishAnimation();
            p.GetComponent<_PlayerAnimation>().enabled = false;
        }
		foreach (GameObject o in toDelete) {
			objects2.Remove (o);
		}
		toDelete.Clear ();
	}

    public void changeTurn()
    {
		timeLeft = 31;
		checkActivated();

		if (fire == true)
			fire = false;

		controlObjects ();
		team = !team;
		toogleObjectTransform (getPlayerOnTurn (), true);

    }

    public void endGame()
    {
        if (team)
        {
            Application.LoadLevel("gameOverGreen_scene");
        }
        else
        {
            Application.LoadLevel("gameOverOrange_scene");
        }
    }

    public void verifyEnd()
    {
        if (objects.Count == 0)
        {
            team = true;
            endGame();
        } else if (objects2.Count == 0) {
            team = false;
            endGame();
        }
    }

    public bool getTim(float timer)
    {
        if (tim >= timer)
        {
            flagTim = !flagTim;
            tim = 0f;
            return true;
        }

        return false;
    }

    public GameObject getPlayerOnTurn()
    {
        if (team)
        {
            if (turn2 == 0)
                return objects2[objects2.Count - 1].gameObject;
            return objects2[turn2 -1].gameObject;
        }
        else
        {
            if (turn == 0)
                return objects[objects.Count -1].gameObject;
            return objects[turn -1].gameObject;
        }
    }
}
