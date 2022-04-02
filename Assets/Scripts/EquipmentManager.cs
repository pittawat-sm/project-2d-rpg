using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [Header("Equipment Slot")]
    public EquipmentSlot handSlot;
    public EquipmentSlot bodySlot;
    public EquipmentSlot accSlot;
    public EquipmentSlot backSlot;
    [Header("Equiped Item Attribute")]
    public AttackAttribute atkAttr;
    public DefenseAttribute defAttr;
    public BodyAttribute bodyAttr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
