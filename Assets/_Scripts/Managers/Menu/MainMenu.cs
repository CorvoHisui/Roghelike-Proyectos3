using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;
    public GameObject optionsScreen;

    private void Start()
    {
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        audioManager.Play("Menu");
    }

    public void StartGame()
    {
        LevelLoader.instance.LoadScene(Loader.Scene.Taberna_1);
    }
    public void LoadGame()
    {
        GameManager.instance.GetComponent<SaveManager>().LoadPlayer();
    }
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
    public void QuitApp()
    {

        Application.Quit();

    }

}
