using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader instance=null;
    public enum Scene{
        MainMenu,
        Taberna,
        LevelOne,
    }
    void Awake()
    {
        if(instance==null)
            instance=this;
        else if(instance!=this)
            Destroy(gameObject);
    }
    public static void Load(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
    
}
