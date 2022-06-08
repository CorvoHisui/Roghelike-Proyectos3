using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { PlayerTurn, EnemyTurn, Win, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;

    public PlayerController playerController;

    public FloatingTextManager floatingTextManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
    public void HandleGameOver()
    {
        LevelLoader.instance.LoadScene(Loader.Scene.MainMenu);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    
 
}
