using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("Item Properties")]
    public new string name;
    [TextArea]
    public string description;
    public Sprite slotImage;
    public Sprite droppedImage;
    public ItemTier tier;
    public ItemType type;
    public bool edible;
    public bool destroyOnDrop;
    public float destroyTime;
    [Header("Freshness Properties")]
    public bool spoilable;
    public float spoilPoint;
    public Item spoilItem;
    [Header("Pricing Properties")]
    public int buyPrice;
    public bool sellable;
    public int fullPrice;
    public int stalePrice;
    [Header("Sound")]
    public AudioClip droppedSound;
    public AudioClip moveSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemTier { normal, uncommon, rare, epic, legendary, mystic, god}
public enum ItemType { material, food, ingredient, quest, weapon, tool, armor, accessory, backpack, misc}