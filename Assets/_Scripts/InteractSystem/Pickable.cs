using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    //public Item item;
    Sprite hasInteractedIcon = null;
    public void Awake()
    {
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
        //Inventory.instance.AddItem(item);
        GetComponent<SpriteRenderer>().sprite=hasInteractedIcon;
        hasInteracted=true;
    }
}
