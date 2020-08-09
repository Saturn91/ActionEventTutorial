using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPauseGameAction : Action
{
    private PausedMenu pausedMenu;

    public override void OnDo()
    {
        pausedMenu.UnPauseGame(); ;
    }

    // Start is called before the first frame update
    void Start()
    {
        PausedMenu[] foundObjects = FindObjectsOfType<PausedMenu>();    //get all defined paused menus
        if (foundObjects.Length == 1)
        {
            pausedMenu = foundObjects[0];   //only one Menu is defined, everything ok
        }
        else
        {
            //more than one or non are defined -> error as there can only be 1 paused menu
            Debug.LogError("no paused menu or more than 1 is defined in project: " + foundObjects.Length);
        }

    }
}
