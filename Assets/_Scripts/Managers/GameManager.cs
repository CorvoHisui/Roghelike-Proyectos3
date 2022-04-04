using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {PlayerTurn, EnemyTurn, Win, GameOver}
public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    public GameState currState;

    public PlayerController playerController;

    public FloatingTextManager floatingTextManager;

    public List<Enemy> enemies;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
            instance=this;
        else if(instance!=this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        //List with remaining enemy actions
        enemies=new List<Enemy>();

        //Start
        InitGame();
    }
    void InitGame(){
        currState = GameState.PlayerTurn;
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case GameState.PlayerTurn:
                HandlePlayerTurn();
            break;

            case GameState.EnemyTurn:
                HandleEnemyTurn();
            break;

            case GameState.GameOver:
                HandleGameOver();
            break;

            default:
            return;
        }
    }

    public void HandlePlayerTurn(){

    }
    public void HandleEnemyTurn(){
        if(enemies.Count==0)
            currState=GameState.PlayerTurn;

        else{
            for (int i = 0; i < enemies.Count; i++)
            {
                //enemies[0].GetComponent<Enemy>().DoAction();
            }
            enemies.Clear();
            currState=GameState.PlayerTurn;
        }
    }
    public void HandleGameOver(){
        LevelLoader.instance.LoadScene(Loader.Scene.MainMenu);
    }


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }
    public void AddEnemyToList(Enemy script){
        enemies.Add(script);
    }
}
