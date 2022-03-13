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
        Time.timeScale=1;
        pauseMenu.SetActive(false);
        isPaused=false;
    }
    public void LoadMenu(){
        Time.timeScale=1;
        LevelLoader.Instance.LoadScene(Loader.Scene.MainMenu);
    }
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale=0;
        isPaused=true;
    }
}
