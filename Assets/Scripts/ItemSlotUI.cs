using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [Header("Item Slot")]
    public ItemSlot slot;
    [Header("UI Settings")]
    public GameObject parentCanvas;
    public GameObject freshnessPanel;
    public Image slotItemImage;
    public GameObject brokenPanel;
    public GameObject actionPanel;
    public GameObject equipBtn;
    public GameObject useBtn;
    public GameObject dropBtn;

    // Update is called once per frame
    void Update()
    {
        HideWhenClickedOutside();
    }

/*    private void OnMouseDrag()
    {
        Debug.Log(Input.mousePosition);
    }*/

    public void SetItemSlotUI()
    {
        if (slot.item != null)
        {
            this.slotItemImage.sprite = this.slot.item.slotImage;
            this.slotItemImage.gameObject.SetActive(true);
            if (this.slot.item.GetType() == typeof(Equipment)) {
                equipBtn.SetActive(true);
                useBtn.SetActive(false);
            } else
            {
                equipBtn.SetActive(false);
                useBtn.SetActive(false);
            }
        } else
        {
            this.slotItemImage.sprite = null;
            this.slotItemImage.gameObject.SetActive(false);
        }
    }

    private void HideWhenClickedOutside()
    {
        if (
            Input.GetMouseButton(0) && 
            actionPanel.activeSelf && 
            !RectTransformUtility.RectangleContainsScreenPoint(
                actionPanel.GetComponent<RectTransform>(),
                Input.mousePosition
                )/* &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                slotItemImage.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main
                )*/
            )
        {
            HideItemAction();
        }
    }

    public void ShowItemInfo()
    {
        this.actionPanel.SetActive(true);
    }

    public void HideItemAction()
    {
        this.actionPanel.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        /*slotItemImage.transform.position = Input.mousePosition;*/
        slotItemImage.raycastTarget = false;
        transform.SetAsLastSibling();
        // Bring parent canvas of draging item to front to protect ui overlaping 
        parentCanvas.GetComponent<Canvas>().sortingOrder += 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        slotItemImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        slotItemImage.transform.position = gameObject.transform.position;
        slotItemImage.raycastTarget = true;
        if (eventData.pointerEnter == null)
        {
            slot.DropItem();
        }
        // Bring parent canvas to original
        parentCanvas.GetComponent<Canvas>().sortingOrder -= 1;
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot dragSlot = eventData.pointerDrag.GetComponent<ItemSlot>();
        ItemSlot dropSlot = eventData.pointerEnter.GetComponent<ItemSlot>();
        Item dragItem = dragSlot.item;
        Item dropItem = dragSlot.item;
        if (dragSlot.item != null)
        {
            if (dropSlot.item != null) // Drop Slot Already has item
            {
                if (dropSlot == dragSlot)
                {
                    return;
                }
                if (dropSlot.IsAllowThisType(dragItem.type) && dragSlot.IsAllowThisType(dropItem.type)) // Check both slot allow each other type
                {
                    // Handle old Item on Drop Slot
                    Item tempItem = dropItem;
                    float currentDurable = dropSlot.currentDurable;
                    float currentSpoilPoint = dropSlot.currentSpoilPoint;
                    // Set drop slot to new item
                    dropSlot.SetItemSlot(dragSlot);
                    // Set drag slot to new item
                    dragSlot.SetItemSlot(tempItem, currentDurable, currentSpoilPoint);
                }
            } else // Drop Slot No Item
            {
                if (dropSlot.IsAllowThisType(dragSlot.item.type)) // Check drop slot allow dragging item type
                {
                    dropSlot.SetItemSlot(dragSlot);
                    dragSlot.ClearItemSlot();
                }
            }
        }
    }
}
