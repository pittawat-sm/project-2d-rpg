using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] slots;

    public void AddItem()
    {

    }

    public bool HasAvailableSlot()
    {
        foreach(ItemSlot slot in slots)
        {
            if (slot.item == null)
            {
                return true;
            }
        }
        return false;
    }
}

/*[System.Serializable]
public class ItemSlot
{
    public Item item;
    public ItemType[] onlyAllowType;
    public float currentSpoilPoint;
    public float currentDurable;
    public float spoilModifyRate;
    [Header("UI Settings")]
    public GameObject slotPanel;
    public GameObject freshnessPanel;
    public Image slotItemImage;
    public GameObject brokenPanel;
    public GameObject actionPanel;
    public GameObject equipBtn;
    public GameObject useBtn;
    public GameObject dropBtn;
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
        foreach(ItemType allowType in this.onlyAllowType)
        {
            if (allowType == inputType)
            {
                return true;
            }
        }
        return false;
    }
}*/
