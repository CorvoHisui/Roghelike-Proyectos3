using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    
    private Image spriteImage;
    private UiItem selectedItem;
    public bool craftingSlot = false;
    public bool craftedItemSlot = false;
    public CraftingSlots craftingSlots;
    private Tooltip tooltip;

    void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();   
        tooltip=FindObjectOfType<Tooltip>();    
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UiItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;     
        }
        else
        {
            spriteImage.color = Color.clear;
        }
        if(craftingSlot)
        {
            craftingSlots.UpdateRecipe();
        }
    }

    //grab Object
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null && !craftedItemSlot)
            {
            Item clone = new Item(selectedItem.item);
            selectedItem.UpdateItem(this.item);
            UpdateItem(clone);
            }
            else if (selectedItem.item == null)
            {
            selectedItem.UpdateItem(this.item);
            if (craftedItemSlot)
            {
                GetComponent<UiCraftResult>().CollectCraftResult(this.item);
            }
            UpdateItem(null);
            }
        }
        else if (selectedItem.item != null && !craftedItemSlot)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.item!=null){
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
