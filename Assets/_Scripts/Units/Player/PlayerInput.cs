using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    [SerializeField]
    private string horizontalAxis="Horizontal";
    [SerializeField]
    private string verticallAxis="Vertical";

    public bool foodUsed = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (TurnManager.instance.CurrentState == GameState.PlayerTurn)
        {
            ManageMovementInput();
        }
         
    }

    private void ManageMovementInput()
    {
        if (Mathf.Abs(Input.GetAxisRaw(horizontalAxis)) == 1f || Mathf.Abs(Input.GetAxisRaw(verticallAxis)) == 1f)
        {
            GameManager.instance.playerController.SetPlayerAction(PlayerController.PlayerAction.Movimiento);
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameManager.instance.playerController.SetPlayerAction(PlayerController.PlayerAction.Consumo);
        }
        if(Input.GetMouseButtonDown(2))
        {
            GameManager.instance.playerController.SetPlayerAction(PlayerController.PlayerAction.Ataque);
        }

    }
}
