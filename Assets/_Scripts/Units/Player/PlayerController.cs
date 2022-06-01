using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerAction { None, Movimiento, Ataque, Consumo, Lanzado}
    private PlayerAction currentAction=PlayerAction.None;

    public void SetPlayerAction(PlayerAction newPlayerAction)
    {
        switch (newPlayerAction)
        {
            case PlayerAction.None:
                break;
            case PlayerAction.Movimiento:
                if (CheckIfMovementIsPossible())
                {
                    currentAction = PlayerAction.Movimiento; 
                }
                break;
            case PlayerAction.Ataque:
                break;
            case PlayerAction.Consumo:
                break;
            case PlayerAction.Lanzado:
                break;
            default:
                break;
        }
    }

    private bool CheckIfMovementIsPossible()
    {
        throw new NotImplementedException();
    }

    private void UpdateMovementData()
    {
        throw new NotImplementedException();
    }

    private bool CheckIfActionIsPossible(PlayerAction actionToCheck)
    {
        if(actionToCheck == PlayerAction.Movimiento)
            {
        }
        throw new NotImplementedException();
    }

    #region Movement

    public Transform movePoint;
    public LayerMask stopMovementMask;
    public LayerMask enemyMask;

    public float moveSpeed = 5f;
    Vector2 movement;

    #endregion

    #region InteractSystem
    //Interaction System
    public Interactable lastInteractable;
 
    public delegate void OnInteractableChangedCallback();
    public OnInteractableChangedCallback onInteractableChangedCallback;
    
    public delegate void OnInteractionCallback();
    public OnInteractionCallback onInteractionCallback;

    public Vector2 lastMovement;
    public Transform lastDirectionPoint;

    #endregion

    #region HEALTH
    public int maxHealth=5;
    public int currHealth;

    public HealthBar healthBar;

    #endregion

    UnitWithTurn unitWithTurn;
    void Start()
    {
        movePoint.parent=null;
        lastDirectionPoint.parent=null;

        unitWithTurn = GetComponent<UnitWithTurn>();

        currHealth=3;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currHealth);
    }
    void Update()
    {
        if (TurnManager.instance.CurrentState != GameState.PlayerTurn)
        {
            return;
        }
        //if (GameManager.instance.currState == GameManager.GameState.PlayerTurn)
        //{
        //    MoveMotor();
        //}
        //else
        //{
        //    return;
        //}
        switch (currentAction)
        {
            case PlayerAction.Movimiento:
                MoveMotor();
                break;
            case PlayerAction.Ataque:
                BasicAttack();
                break;
            case PlayerAction.Consumo:
                break;
            case PlayerAction.Lanzado:
                break;
            case PlayerAction.None:
                break;
            default:
                break;
        }
        
        
        
    }
    public void SetLastInteractable(GameObject _LastInteractable)
    {
        if(_LastInteractable==null){
            lastInteractable=null;
        }
        else{
            lastInteractable = _LastInteractable.GetComponent<Interactable>();
            onInteractableChangedCallback?.Invoke(); 
        }
        
        // notify all listeners
            
    }
    

    public void MoveMotor(){
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        transform.position=Vector3.MoveTowards(transform.position,movePoint.position, moveSpeed*Time.deltaTime);
        lastDirectionPoint.position = Vector3.MoveTowards(lastDirectionPoint.position, movePoint.position + new Vector3(lastMovement.x, lastMovement.y, 0), 16 * Time.fixedDeltaTime);

        //change state
        if (Vector3.Distance(transform.position, movePoint.position) <= .001f)
        {
            unitWithTurn.turnCompleted = true;
            return;
        }
        Vector3 lastPosition = transform.position;
        //Move point
        if (Mathf.Abs(movement.x) == 1f){

            movePoint.position += new Vector3(movement.x, 0f, 0f);
            lastMovement=movement;

            
        }
        else if (Mathf.Abs(movement.y) == 1f){
            
            movePoint.position += new Vector3(0f, movement.y, 0f);
            lastMovement=movement;
        }
        
        //Check overlap
        if (Physics2D.OverlapCircle(movePoint.position, .05f, stopMovementMask)){

            movePoint.position = lastPosition;
        }

        
    }

    public void onPressAction()
    {
        if (lastInteractable != null)
        {
            lastInteractable.Interact();
            // notify all listeners that player has interacted with 'faced interactable object'
            onInteractionCallback?.Invoke();     
        }
    }
    
    public void BasicAttack(){
        Debug.Log("Enemy attacked");
    }
    
    public void TakeDamage(int damage){
        currHealth-=damage;
        healthBar.SetHealth(currHealth);
    }

}
