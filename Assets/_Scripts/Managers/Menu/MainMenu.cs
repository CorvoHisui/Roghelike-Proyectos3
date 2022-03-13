using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsScreen;
    public void StartGame(){
        LevelLoader.Instance.LoadScene(Loader.Scene.LevelOne);
    }
    public void OpenOptions(){
        optionsScreen.SetActive(true);
    }
    public void CloseOptions(){
        optionsScreen.SetActive(false);
    }
    public void QuitApp(){
        
    }
    
}