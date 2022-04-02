using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory baseInventory;
    public Inventory backpackInventory;
    public bool AddItem(ItemSlot newItem)
    {
        bool success = false;
        foreach(ItemSlot slot in baseInventory.slots)
        {
            if (slot.item == null && slot.IsAllowThisType(newItem.item.type))
            {
                slot.SetItemSlot(newItem);
                success = true;
                break;
            }
        }
        if (!success && backpackInventory != null)
        {
            foreach (ItemSlot slot in backpackInventory.slots)
            {
                if (slot.item == null && slot.IsAllowThisType(newItem.item.type))
                {
                    slot.SetItemSlot(newItem);
                    success = true;
                    break;
                }
            }
        }
        return success;
    }
}
