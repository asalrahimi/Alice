using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void Click_Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Click_Next_Level(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }
}
