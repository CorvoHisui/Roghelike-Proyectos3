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
        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetMouseButtonDown(1))
        {
            if (this.item != null) //clicking on item
            {
                if (selectedItem.item == null) //following empty
                {
                    Debug.Log("tried to use");
                    Debug.Log(this.item.stats["Health"]);
                    
                    GameManager.instance.playerController.heal(this.item.stats["Health"]);
                    UpdateItem(null);
                    PlayerInput.instance.foodUsed = true;
                }
                
            }

        }
        if (Input.GetMouseButtonDown(2))
        {
            if (this.item != null) //clicking on item
            {
                if (selectedItem.item == null) //following empty
                {
                    Debug.Log("tried to use");
                    
                    int health = this.item.stats["Health"];
                    Debug.Log(health);

                    //Shoot this.item
                    GameObject bullet = Instantiate(GameManager.instance.bulletPrefab, GameManager.instance.playerController.lastDirectionPoint.position, GameManager.instance.playerController.lastDirectionPoint.rotation);

                    bullet.GetComponent<SpriteRenderer>().sprite = this.item.icon;
                    bullet.GetComponent<Bullet>().damage = health;
                    
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce((GameManager.instance.playerController.lastDirectionPoint.position - GameManager.instance.playerController.transform.position)* 10f, ForceMode2D.Impulse);

                    UpdateItem(null);
                    PlayerInput.instance.foodUsed = true;
                }

            }
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
