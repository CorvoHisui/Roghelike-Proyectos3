using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;

    public static bool isInventory;
    public GameObject inventoryMenu;
    void Start()
    {
        HideInventory();
    }
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

        if(Input.GetKeyDown(KeyCode.I)){
            if(isInventory){
                HideInventory();
            }
            else{
                ShowInventory();
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

    //si empieza apagado no funciona
    void HideInventory(){
        inventoryMenu.SetActive(false);
        isInventory=false;
    }
    void ShowInventory(){
        inventoryMenu.SetActive(true);
        isInventory=true;
    }
}
