using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask stopMovementMask;
    public LayerMask enemyMask;

    public float moveSpeed = 5f;
    Vector2 movement;

    //Interaction System
    public Interactable lastInteractable;
 
    public delegate void OnInteractableChangedCallback();
    public OnInteractableChangedCallback onInteractableChangedCallback;
    
    public delegate void OnInteractionCallback();
    public OnInteractionCallback onInteractionCallback;

    public Vector2 lastMovement;
    public Transform lastDirectionPoint;

    void Start()
    {
        movePoint.parent=null;
        lastDirectionPoint.parent=null;
    }
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        transform.position=Vector3.MoveTowards(transform.position,movePoint.position, moveSpeed*Time.deltaTime);
        lastDirectionPoint.position = Vector3.MoveTowards(lastDirectionPoint.position, movePoint.position + new Vector3(lastMovement.x, lastMovement.y, 0), 8 * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .001f)
        {
            if (Mathf.Abs(movement.x) == 1f){

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0.5f, 0f), .01f, stopMovementMask)){

                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }
                lastMovement=movement;
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0.5f, 0f), .01f, enemyMask)){

                    BasicAttack();
                }
            } 
            else if (Mathf.Abs(movement.y) == 1f){
                
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0.5f, movement.y, 0f), .01f, stopMovementMask)){

                    movePoint.position += new Vector3(0f, movement.y, 0f);
                }
                lastMovement=movement;
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0.5f, movement.y, 0f), .01f, enemyMask)){

                    BasicAttack();
                }
            }
        }
    }
    public void SetLastInteractable(Interactable _LastInteractable)
    {
        lastInteractable = _LastInteractable;
        // notify all listeners
        onInteractableChangedCallback.Invoke();     
    }
    
    public void onPressAction()
    {
        if (lastInteractable != null)
        {
            lastInteractable.Interact();
            // notify all listeners that player has interacted with 'faced interactable object'
            onInteractionCallback.Invoke();     
        }
    }

    public void BasicAttack(){
        Debug.Log("Enemy attacked");
    }
}
