using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ItemDatabase itemDatabase;
    [SerializeField]
    public List<Item> playerItems = new List<Item>();
    [SerializeField]
    private UiInventory inventoryUi;

    void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
    }
    void Start()
    {
        GiveItem(1);
        GiveItem(1);

        GiveItem(2);
        GiveItem(2);

        GiveItem(3);
        GiveItem(3);

        GiveItem(4);
        GiveItem(4);
        GiveItem(4);
        GiveItem(4);

        GiveItem(5);
        GiveItem(5);

        GiveItem(6);
        GiveItem(6);

        GiveItem(7);
        GiveItem(7);
        
        GiveItem(8);
        GiveItem(8);
    }
    public void GiveItem(int id){
        Item itemToAdd = itemDatabase.GetItem(id);
        inventoryUi.AddItemToUi(itemToAdd);
        playerItems.Add(itemToAdd);
    }
    public void GiveItem(string itemName){
        Item itemToAdd = itemDatabase.GetItem(itemName);
        inventoryUi.AddItemToUi(itemToAdd);
        playerItems.Add(itemToAdd);
    }
    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        playerItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id){
        return playerItems.Find(item => item.id == id);
    }
    public Item CheckForItem(string title){
        return playerItems.Find(item => item.title == title);
    }

    public void RemoveItem(int id){
        Item itemToRemove = CheckForItem(id);
        if(itemToRemove!=null){
            playerItems.Remove(itemToRemove);
        }
    }
}
