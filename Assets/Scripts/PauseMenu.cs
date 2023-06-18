using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{      
    public GameObject PauseMenuUI;
        int saved_scene;
    int scene_index;
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
       Application.Quit();
    }
    public void MenuLoad()
    {
       Debug.Log("Menu is loading");
               scene_index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved",scene_index);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
        Time.timeScale=1f;


    }
       public void loadSavedScene(){
        print("its loaded");
        saved_scene = PlayerPrefs.GetInt("Saved");
            print("true");
            SceneManager.LoadSceneAsync(saved_scene);
 
    }
}
