using System;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour, IInteract
{
    protected PlayerController playerController;
    public bool isTriggerInstant;
    protected bool hasInteracted;
    protected GameObject entity;

    // void Awake()
    // {
    //     playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    // }
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
    // private void OnTriggerEnter2D(Collider2D other) {

    //     PlayerController playerController = other.GetComponentInParent<PlayerController>();
    //     if(playerController !=null &&  !hasInteracted){
    //         entity=this.gameObject;
    //         playerController.SetLastInteractable(entity);

    //         if(isTriggerInstant){
    //             playerController.onPressAction();
    //         }
    //     }
        
    // }
    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("trigger");
        PlayerController playerController = other.GetComponentInParent<PlayerController>(); //other no tiene padre

        if(playerController !=null && !hasInteracted){
            entity=this.gameObject;
            playerController.SetLastInteractable(entity);
            if(isTriggerInstant){
                playerController.onPressAction();
            }
        }
        else if(playerController !=null && hasInteracted){
            entity=null;
            playerController.SetLastInteractable(null);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        entity=null;
        playerController.SetLastInteractable(null);
    }
}