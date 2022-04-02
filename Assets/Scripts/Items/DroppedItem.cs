using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [Header("System Settings")]
    public bool destroyObj = false;
    [Header("Item Properties")]
    public ItemSlot slot;
    public float destroyCountdown = 120f; /*In second unit*/
    public float currentCountdownTime;
    public SpriteRenderer sr;
    public GameObject actionObjUI;
    public Unit playerUnit;
    // Start is called before the first frame update

    private void Awake()
    {
        if (slot.item != null)
        {
            destroyObj = slot.item.destroyOnDrop;
            destroyCountdown = slot.item.destroyTime;
        }
    }

    private void Start()
    {
        if (slot != null)
        {
            sr.sprite = slot.item.droppedImage;
        }
    }

    private void FixedUpdate()
    {
        if (!destroyObj)
        {
            return;
        }
        currentCountdownTime += Time.fixedDeltaTime;
        if (currentCountdownTime >= destroyCountdown)
        {
            Object.Destroy(gameObject);
        }
    }

    public void Pickup()
    {
        if (playerUnit != null)
        {
            bool pickupSuccess = playerUnit.invManager.AddItem(slot);
            if (pickupSuccess)
            {
                Object.Destroy(gameObject);
            }
        } 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
     /*   Debug.Log(collision.gameObject.name);*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit enteredUnit = collision.gameObject.GetComponent<Unit>();
        if (enteredUnit != null)
        {
            if (enteredUnit.gameObject.CompareTag("Player"))
            {
                ShowActionUI();
                playerUnit = enteredUnit;
            }
        }
        //Debug.Log(enteredUnit);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        HideActionUI();
    }

    public void ShowActionUI()
    {
        actionObjUI.SetActive(true);
    }

    public void HideActionUI()
    {
        actionObjUI.SetActive(false);
    }
}
