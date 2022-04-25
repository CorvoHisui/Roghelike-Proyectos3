using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsScreen;
    public void StartGame(){
        LevelLoader.instance.LoadScene(Loader.Scene.Taberna_1);
    }
    public void OpenOptions(){
        optionsScreen.SetActive(true);
    }
    public void CloseOptions(){
        optionsScreen.SetActive(false);
    }
    public void QuitApp(){
        
        Application.Quit();
        
    }
    
}
