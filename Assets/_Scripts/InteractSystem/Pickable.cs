using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    //public Item item;
    public Sprite hasInteractedIcon = null;
    //private inventory inventory;
    public GameObject itemButton;
    /*
    public void Awake()
    {
        inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        if(hasInteracted){
            GetComponent<SpriteRenderer>().sprite=hasInteractedIcon;
        }
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    
    void PickUp(){
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.isFull[i]==false){
                //ADD item to inventory
                inventory.isFull[i]=true;
                Instantiate(itemButton, inventory.slots[i].transform);
                break;
            }
        }

        if(hasInteractedIcon!=null){
            GetComponent<SpriteRenderer>().sprite=hasInteractedIcon;
            hasInteracted=true;
        }
        else{
            Destroy(gameObject);
            Debug.Log("item destroyed");
        }
        
    }
    */
}
