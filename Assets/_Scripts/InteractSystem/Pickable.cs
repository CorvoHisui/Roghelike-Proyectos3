using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    public List<int> item= new List<int>();
    public AudioManager audioManager;
    public Sprite hasInteractedIcon = null;
    
    public void Awake()
    {
        if(hasInteracted){
            GetComponent<SpriteRenderer>().sprite=hasInteractedIcon;
        }
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        audioManager.Play("Cofre");
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    
    void PickUp(){
        for (int i = 0; i < item.Count; i++)
        {
            //AudioManager.instance.Play("Cofre");
            GameManager.instance.playerController.gameObject.GetComponent<Inventory>().GiveItem(item[i]);
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
    
}
