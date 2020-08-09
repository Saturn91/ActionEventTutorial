using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedGameMenuParent;
    public OnPressButtonEvent listenForPauseGameButtonEvent;

    public void Start()
    {
        pausedGameMenuParent.SetActive(false);    
    }

    public void PauseGame()
    {
        //pause all game movements
        Time.timeScale = 0;
        //open Gamemenu
        pausedGameMenuParent.SetActive(true);
        //deactivate PauseGameButton
        listenForPauseGameButtonEvent.enabled = false;
    }

    public void UnPauseGame()
    {
        //unpause all game movements
        Time.timeScale = 1;
        //close Gamemenu
        pausedGameMenuParent.SetActive(false);
        //reactivate PauseGameButton
        listenForPauseGameButtonEvent.enabled = true;
    }
}
