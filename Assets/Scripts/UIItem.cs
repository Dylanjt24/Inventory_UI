using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;

    private void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>(); // Grab the UIItem component from the selected item
        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        spriteImage = GetComponent<Image>(); // Grabs the item's icon
        UpdateItem(null); // Sets slots to null on awake
    }

    // Updates the item in that slot based on given item
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
    }

    // Fires whenever an item is clicked on
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            // If an item is already selected (or being dragged)
            if (selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item); // Clone the replaced item to keep a reference to that item
                selectedItem.UpdateItem(this.item); // Set seleceted item to be the item you clicked on
                UpdateItem(clone); // Update the item in the slot you removed an item from to be the item you replaced with the selected item
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null); // Make the old item slot null since you didn't replace it with anything
            }
        }
        // Put your selected item in an empty inventory slot
        else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    // Generate tooltip when hovering over item
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
            tooltip.GenerateTooltip(this.item);
    }

    // Deactivate tooltip when done hovering
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
