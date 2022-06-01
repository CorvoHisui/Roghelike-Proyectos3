using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    [SerializeField]
    GameState currState;
    public GameState CurrentState => currState;

    public List<UnitWithTurn> units;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {       
        units = new List<UnitWithTurn>(FindObjectsOfType<UnitWithTurn>());
        SetGameState(GameState.PlayerTurn);
    }

    void SetGameState (GameState newGameState)
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].turnCompleted = false;
        }
        currState = newGameState;
    }


    // Update is called once per frame
    void Update()
    {
        if (CheckIfNextTurn())
        {
            Debug.Log("nextTurn");
            GameState nextState=GameState.PlayerTurn;
            if (currState == GameState.PlayerTurn)
            {
                nextState = GameState.EnemyTurn;
            }

            if (currState == GameState.EnemyTurn)
            {
                nextState = GameState.PlayerTurn;
            }

            SetGameState(nextState);
        }
    }

    private bool CheckIfNextTurn()
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (currState == GameState.PlayerTurn && units[i].isPlayer)
            {
                return units[i].turnCompleted;
            }

            if (currState == GameState.EnemyTurn)
            {
                if (!units[i].isPlayer && !units[i].turnCompleted)
                {
                    return false;
                }
            }
        }
        return true;
    }
}

