using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPanel : MonoBehaviour
{
    public List<UiItem> uiItems = new List<UiItem>();
    public int numberOfSlots;
    public GameObject slotPrefab;
    public Inventory inventory;
    void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(transform);
            uiItems.Add(instance.GetComponentInChildren<UiItem>());
            uiItems[i].item = null;
        }
    }
    public void UpdateSlot(int slot, Item item){
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item){
        UpdateSlot(uiItems.FindIndex(i => i.item==null), item);
    }

    public void RemoveItem(Item item){
        UpdateSlot(uiItems.FindIndex(i => i.item==item), null);
    }
    public void EmptyAllSlots()
    {
        uiItems.ForEach(i =>
        {
            // remove item from the inventory
            if (i.item != null)
            {
            inventory.RemoveItem(i.item.id);
            }
            i.UpdateItem(null);
        });
    }
    public bool ContainsEmptySlot(){
        foreach (UiItem uii in uiItems)
        {
            if(uii.item == null) 
                return true;
        }
        return false;
    }
}
