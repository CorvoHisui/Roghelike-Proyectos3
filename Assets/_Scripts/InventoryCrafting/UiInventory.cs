using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    [SerializeField]
    private SlotPanel[] slotsPanels;

    public void AddItemToUi(Item item){
        foreach (SlotPanel sp in slotsPanels)
        {
            if(sp.ContainsEmptySlot()){
                sp.AddNewItem(item);
                break;
            }
        }
    }
}
