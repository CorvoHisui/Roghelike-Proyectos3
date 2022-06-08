using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    EnemyAi enemy;
    bool actionPerformed = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyAi>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnManager.instance.CurrentState != GameState.EnemyTurn)
        {
            actionPerformed = false;
            return;
        }

        if (actionPerformed==false && TurnManager.instance.CurrentState == GameState.EnemyTurn)
        {
            enemy.SetEnemyAction(EnemyAi.EnemyAction.Movimiento);
            actionPerformed = true;
            Debug.Log("changed Enemy action");
        }
    }
}
