using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Syrinj;

public class MenuScript : MonoBehaviour {

    public GameObject tutorial;

    [Inject]
    private string nextLevel;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("START"))
        {
            chooseSceene();
        }
    }

    public void chooseSceene()
    {
        Application.LoadLevel(nextLevel);
    }

    public void chooseSceene(string s)
    {
        Application.LoadLevel(s);
    }

    public void restart()
    {
        chooseSceene("noite_scene");
    }

    public void togglePause()
    {
        var s = Manager.getInstance().getMachine().getCurrentState();
        if(Manager.getInstance().getMachine().getCurrentState() is PlayingState)
        {
            Manager.getInstance().getMachine().changeState(PausedState.getInstance());
        } else
        {
            Manager.getInstance().getMachine().changeState(PlayingState.getInstance());
        }
        
    }
    public void toggleWeapon()
    {
        if (Manager.getInstance().getMachine().getCurrentState() is WeaponState)
        {
            Manager.getInstance().getMachine().changeState(PlayingState.getInstance());
        } else
        {
            Manager.getInstance().getMachine().changeState(WeaponState.getInstance());
        }
    }
}
