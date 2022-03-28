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
    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other!=null && !hasInteracted){
            entity=this.gameObject;
            playerController.SetLastInteractable(this);
        }
        if(isTriggerInstant){
            playerController.onPressAction();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other!=null && !hasInteracted){
            entity=this.gameObject;
            playerController.SetLastInteractable(this);
        }
        else if(other!=null && hasInteracted){
            entity=null;
            playerController.SetLastInteractable(null);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        entity=null;
        playerController.SetLastInteractable(null);
    }
}