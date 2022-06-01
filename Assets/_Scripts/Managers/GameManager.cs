using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { PlayerTurn, EnemyTurn, Win, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    //public GameState currState;

    public PlayerController playerController;

    public FloatingTextManager floatingTextManager;

    //public List<EnemyAi> enemies;
    //bool enemyTurnHandled = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    //void InitGame(){
    //    currState = GameState.PlayerTurn;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    switch (currState)
    //    {
    //        case GameState.PlayerTurn:
    //            HandlePlayerTurn();
    //        break;

    //        case GameState.EnemyTurn:

    //                HandleEnemyTurn();
    //        break;

    //        case GameState.GameOver:
    //            HandleGameOver();
    //        break;

    //        default:
    //        return;
    //    }
    //    if(Input.GetKeyDown(KeyCode.Tab)){
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}

    //public void HandlePlayerTurn(){

    //}

    //public void HandleEnemyTurn(){
    //    if(CheckIfTurnEnded())
    //    {
    //        for (int i = 0; i < enemies.Count; i++)
    //        {
    //            enemies[i].GetComponent<EnemyAi>().turnMade = false;
    //        }

    //        currState = GameState.PlayerTurn;
    //    }
    //    //Logica del turno
    //    if(enemies.Count==0)
    //        currState=GameState.PlayerTurn;
    //    else{

    //        for (int i = 0; i < enemies.Count; i++)
    //        {
    //            enemies[i].GetComponent<EnemyAi>().Move();
    //        }
    //    }

    //}

    //private bool CheckIfTurnEnded(){

    //    bool enemyTurnFinished=false;
    //    for (int i = 0; i < enemies.Count; i++){
    //            if(enemies[i].GetComponent<EnemyAi>().turnMade){
    //                enemyTurnFinished=true;
    //            }
    //            else{
    //                return false;
    //            }

    //    }
    //    return enemyTurnFinished;
    //}
    public void HandleGameOver()
    {
        LevelLoader.instance.LoadScene(Loader.Scene.MainMenu);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    //public void AddEnemyToList(EnemyAi script){
    //    enemies.Add(script);
    //}
}
