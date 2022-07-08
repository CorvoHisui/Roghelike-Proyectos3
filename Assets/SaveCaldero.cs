using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCaldero : Interactable
{
    public Sprite hasInteractedIcon = null;
    

    public void Awake()
    {
        if (hasInteracted)
        {
            GetComponent<SpriteRenderer>().sprite = hasInteractedIcon;
        }


    }
    public override void Interact()
    {
        base.Interact();
        GameManager.instance.GetComponent<SaveManager>().SavePlayer();
        
    }
}
