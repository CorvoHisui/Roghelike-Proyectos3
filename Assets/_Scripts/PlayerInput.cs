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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Mathf.Abs(Input.GetAxisRaw(horizontalAxis)) >= 0.1f || Mathf.Abs(Input.GetAxisRaw(verticallAxis)) >= 0.1f)
        {
            GameManager.instance.playerController.SetPlayerAction(PlayerController.PlayerAction.Movimiento);
        }

    }
}
