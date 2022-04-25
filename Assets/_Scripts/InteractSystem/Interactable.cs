using System;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour, IInteract
{
    protected PlayerController playerController;
    public bool isTriggerInstant;
    protected bool hasInteracted;
    protected GameObject entity;
    public virtual void Interact(){
        if (entity == null || hasInteracted){
            return;
        }
        else if(entity!=null){
            Debug.Log("interacted with "+ entity.name);
        }
    }
    public GameObject GetCurrentEntity(){
        return entity;
    }
     /* 
    private void OnTriggerEnter2D(Collider2D other) {

        playerController = GameManager.instance.playerController;

        if(playerController !=null &&  !hasInteracted){
            entity=this.gameObject;
            playerController.SetLastInteractable(entity);

            if(isTriggerInstant){
                playerController.onPressAction();
            }
        }
        
    } */
    
    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("trigger");
        playerController = GameManager.instance.playerController;
        if(playerController !=null && !hasInteracted){
            entity=this.gameObject;
            //have to get interactable scrip instead of specific variation
            playerController.SetLastInteractable(entity);
            if(isTriggerInstant){
                playerController.onPressAction();
                Debug.Log("Pressed Action");
            }
        }
        else if(playerController !=null && hasInteracted){
            entity=null;
            playerController.SetLastInteractable(entity);
        }
    } 
    private void OnTriggerExit2D(Collider2D other) {
        playerController = GameManager.instance.playerController;
        entity=null;
        playerController.SetLastInteractable(null);
    }
}