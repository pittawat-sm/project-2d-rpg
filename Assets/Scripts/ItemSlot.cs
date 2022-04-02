using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [Header("Item Properties")]
    public Item item;
    [Tooltip("Use to locate inventory position for drop item")]
    public Inventory inventory;
    public ItemType[] onlyAllowType;
    public float currentSpoilPoint;
    public float currentDurable;
    public float spoilModifyRate;
    [Header("UI Settings")]
    public ItemSlotUI ui;

    public bool IsAllowAll()
    {
        if (this.onlyAllowType.Length == 0)
        {
            return true;
        }
        return false;
    }

    public bool IsAllowThisType(ItemType inputType)
    {
        if (this.IsAllowAll())
        {
            return true;
        }
        foreach (ItemType allowType in this.onlyAllowType)
        {
            if (allowType == inputType)
            {
                return true;
            }
        }
        return false;
    }

    public void DropItem()
    {
        if (this.item != null)
        {
            GameObject loadObj = (GameObject)Instantiate(
                Resources.Load("Items/Dropped Item"), 
                inventory.gameObject.transform.position, 
                new Quaternion()
                );
            DroppedItem droppedItem = loadObj.GetComponent<DroppedItem>();
            droppedItem.slot.item = this.item;
            droppedItem.slot.currentDurable = this.currentDurable;
            droppedItem.slot.currentSpoilPoint = this.currentSpoilPoint;
            ClearItemSlot();
        }
    }

    public bool SetItemSlot(ItemSlot newItem)
    {
        if (!IsAllowThisType(newItem.item.type))
        {
            return false;
        }
        this.item = newItem.item;
        this.currentDurable = newItem.currentDurable;
        this.currentSpoilPoint = newItem.currentSpoilPoint;
        if (this.ui != null)
        {
            this.ui.SetItemSlotUI();
        }
        return true;
    }

    public bool SetItemSlot(Item item, float durable, float spoilPoint)
    {
        if (!IsAllowThisType(item.type))
        {
            return false;
        }
        this.item = item;
        this.currentDurable = durable;
        this.currentSpoilPoint = spoilPoint;
        if (this.ui != null)
        {
            this.ui.SetItemSlotUI();
        }
        return true;
    }

    public void ClearItemSlot()
    {
        this.item = null;
        this.currentDurable = 0;
        this.currentSpoilPoint = 0;
        if (this.ui != null)
        {
            this.ui.SetItemSlotUI();
        }
    }
}
