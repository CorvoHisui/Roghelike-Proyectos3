using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        isPaused=false;
    }

    public void LoadMenu(){
        LevelLoader.instance.LoadScene(Loader.Scene.MainMenu);
    }

    void Pause(){
        pauseMenu.SetActive(true);
        isPaused=true;
    }
}
