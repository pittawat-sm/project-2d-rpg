using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment", order = 1)]
public class Equipment : Item
{
    [Header("Durable Properties")]
    public bool breakable;
    public float durable;
    /*Durable Burnout Point for each condition of equipment type*/
    public float durableDrainPoint;
    [Header("Attribute Properties")]
    public AttackAttribute atkAttr;
    public DefenseAttribute defAttr;
    public BodyAttribute bodyAttr;
}
