using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : StaticInstance<Loader>
{
    public enum Scene{
        MainMenu,
        Taberna,
        LevelOne,
    }
    public static void Load(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
    
}
