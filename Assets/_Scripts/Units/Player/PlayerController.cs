using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerAction { None, Movimiento, Ataque, Consumo, Lanzado}
    private PlayerAction currentAction=PlayerAction.None;

    #region Movement

    public Transform movePoint;
    public LayerMask stopMovementMask;
    public LayerMask enemyMask;

    public float moveSpeed = 5f;
    Vector2 movement;

    #endregion

    public void SetPlayerAction(PlayerAction newPlayerAction){
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
                currentAction = PlayerAction.Ataque;
                break;
            case PlayerAction.Consumo:
                currentAction = PlayerAction.Consumo;
                break;
            case PlayerAction.Lanzado:
                break;
            default:
                break;
        }
    }
    private bool CheckIfMovementIsPossible(){
        Vector3 lastPosition = transform.position;
        

        //Check overlap
        if (Physics2D.OverlapCircle(movePoint.position, .05f, stopMovementMask))
        {

            movePoint.position = lastPosition;
            return false;
        }
        return true;
        
    }

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

    void Start(){
        movePoint.parent=null;
        lastDirectionPoint.parent=null;

        unitWithTurn = GetComponent<UnitWithTurn>();

        currHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currHealth);
    }
    void Update(){
        if (TurnManager.instance.CurrentState != GameState.PlayerTurn)
        {
            return;
        }
        switch (currentAction)
        {
            case PlayerAction.Movimiento:
                MoveMotor();
                break;
            case PlayerAction.Ataque:
                BasicAttack();
                break;
            case PlayerAction.Consumo:
                ItemUsed();
                break;
            case PlayerAction.Lanzado:
                break;
            case PlayerAction.None:
                break;
            default:
                break;
        }
    }

    private void ItemUsed(){
        unitWithTurn.turnCompleted = true;
        currentAction = PlayerAction.None;
    }

    public void SetLastInteractable(GameObject _LastInteractable){
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            movePoint.position += new Vector3(0f, 1f, 0f);
            lastMovement = new Vector3(0f, 1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
            lastMovement = new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
            lastMovement = new Vector3(0f, -1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
            lastMovement = new Vector3(1f, 0f, 0f);
        }

        
        transform.position=Vector3.MoveTowards(transform.position,movePoint.position, moveSpeed*Time.deltaTime);
        lastDirectionPoint.position = Vector3.MoveTowards(lastDirectionPoint.position, movePoint.position + new Vector3(lastMovement.x, lastMovement.y, 0), 16 * Time.fixedDeltaTime);

        

        
        //change state
        if (Vector3.Distance(transform.position, movePoint.position) <= .001f)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x * 2f) * 0.5f, Mathf.Round(transform.position.y * 2f) * 0.5f, Mathf.Round(transform.position.z * 2f) * 0.5f);

            unitWithTurn.turnCompleted = true;
            currentAction = PlayerAction.None;
            return;
        }
    }

    public void onPressAction(){
        if (lastInteractable != null)
        {
            lastInteractable.Interact();
            // notify all listeners that player has interacted with 'faced interactable object'
            onInteractionCallback?.Invoke();     
        }
    }
    
    public void BasicAttack(){
        Debug.Log("Attack");

        unitWithTurn.turnCompleted = true;
        currentAction = PlayerAction.None;
    }
    
    public void heal(int hp){
        currHealth += hp;
        healthBar.SetHealth(currHealth);
        if (currHealth <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadScene(Loader.Scene.GameOver);
        }
    }

    public void TakeDamage(int damage){

        Debug.Log("player Damaged");

        currHealth-=damage;

        healthBar.SetHealth(currHealth);

        if (currHealth <= 0)
        {
            Debug.Log("GameOver");
        }
    }


}
