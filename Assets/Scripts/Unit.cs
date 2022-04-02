using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Health & Stamina")]
    public float currentHealth;
    public float injuryPoint;
    public float healthBurnPoint;
    public float currentStamina;
    public float staminaBurnPoint;
    [Header("Unit Base Attribute")]
    public AttackAttribute atkAttr;
    public DefenseAttribute defAttr;
    public BodyAttribute bodyAttr;
    [Header("System & Manager")]
    public AttributeManager attrManager;
    public EquipmentManager equipManager;
    public ItemDropManager dropManager;
    public InventoryManager invManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
