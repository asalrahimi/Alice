using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    int saved_scene;
    int scene_index;

    public void SaveAndExit(){
        scene_index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved",scene_index);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }
    public void loadSavedScene(){
        print("its loaded");
        saved_scene = PlayerPrefs.GetInt("Saved");
        if(saved_scene==0){
            print("true");
            SceneManager.LoadSceneAsync(saved_scene);
        }else{
            print("false");
            return;
        }
    }
    public void QuitGame(){
        Application.Quit();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
