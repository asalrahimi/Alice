using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{      
    public GameObject PauseMenuUI;
    public static bool GameIsPaused=false;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(value: false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    public void Quit()
    {
       Debug.Log("quiting Game");
    }
    public void MenuLoad()
    {
       Debug.Log("Menu is loading");

    }
}
