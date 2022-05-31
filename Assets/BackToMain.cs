using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour
{
    public void MainMenu(){
        LevelLoader.instance.LoadScene(Loader.Scene.MainMenu);
    }
}
