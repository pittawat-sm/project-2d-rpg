using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    public Unit unit;
    [Header("Calculated Attribute")]
    public AttackAttribute atkAttr;
    public DefenseAttribute defAttr;
    public BodyAttribute bodyAttr;
    // Start is called before the first frame update
    void Start()
    {
        atkAttr.ResetAttribute();
        atkAttr.AddAttribute(unit.atkAttr);

        defAttr.ResetAttribute();
        defAttr.AddAttribute(unit.defAttr);

        bodyAttr.ResetAttribute();
        bodyAttr.AddAttribute(unit.bodyAttr);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class AttackAttribute
{
    [Header("Base Attribute")]
    public float damage;
    public float attackSpeed;
    public float attackRange;
    [Range(0, 1f)]
    public float criRate;
    public float criDamage;
    [Header("Damage Type Proc Rate")]
    [Range(0, 1f)]
    public float bluntProcRate;
    [Range(0, 1f)]
    public float slashProcRate;
    [Range(0, 1f)]
    public float stabProcRate;
    [Range(0, 1f)]
    public float chopProcRate;
    [Range(0, 1f)]
    public float mineProcRate;
    [Header("Element Damage Attribute")]
    /*(Lighning > Water > Fire > Earth > Wind > Lightning) (Dark > Light > Dark)*/
    public float lightningDmg;
    public float waterDmg;
    public float fireDmg;
    public float earthDmg;
    public float windDmg;
    public float darkDmg;
    public float lightDmg;

    public void ResetAttribute()
    {
        damage = 0;
        attackSpeed = 0;
        attackRange = 0;

        criRate = 0;
        criDamage = 0;

        bluntProcRate = 0;
        slashProcRate = 0;
        stabProcRate = 0;
        chopProcRate = 0;
        mineProcRate = 0;

        lightningDmg = 0;
        waterDmg = 0;
        earthDmg = 0;
        windDmg = 0;
        darkDmg = 0;
        lightDmg = 0;
    }

    public void AddAttribute(AttackAttribute inputAttr)
    {
        damage += inputAttr.damage;
        attackSpeed += inputAttr.attackSpeed;
        attackRange += inputAttr.attackRange;

        criRate += inputAttr.criRate;
        criDamage += inputAttr.criDamage;

        bluntProcRate = inputAttr.bluntProcRate;
        slashProcRate = inputAttr.slashProcRate;
        stabProcRate = inputAttr.stabProcRate;
        chopProcRate = inputAttr.chopProcRate;
        mineProcRate = inputAttr.mineProcRate;

        lightningDmg += inputAttr.lightningDmg;
        waterDmg += inputAttr.waterDmg;
        earthDmg += inputAttr.earthDmg;
        windDmg += inputAttr.windDmg;
        darkDmg += inputAttr.darkDmg;
        lightDmg += inputAttr.lightDmg;
    }
}

[System.Serializable]
public class DefenseAttribute
{
    [Header("Base Attribute")]
    public float defense;
    [Range(0, 1f)]
    public float blockRate;
    [Header("Damage Type Reduction")]
    [Range(0, 1f)]
    public float bluntDmgReduction;
    [Range(0, 1f)]
    public float slashDmgReduction;
    [Range(0, 1f)]
    public float stabDmgReduction;
    [Range(0, 1f)]
    public float chopDmgReduction;
    [Range(0, 1f)]
    public float mineDmgReduction;
    [Header("Element Resistance Attribute")]
    /*(Lighning > Water > Fire > Earth > Wind > Lightning) (Dark > Light > Dark)*/
    public float lightningRes;
    public float waterRes;
    public float fireRes;
    public float earthRes;
    public float windRes;
    public float darkRes;
    public float lightRes;

    public void ResetAttribute()
    {
        defense = 0;
        blockRate = 0;

        bluntDmgReduction = 0;
        slashDmgReduction = 0;
        stabDmgReduction = 0;

        lightningRes = 0;
        waterRes = 0;
        fireRes = 0;
        earthRes = 0;
        windRes = 0;
        darkRes = 0;
        lightRes = 0;
    }

    public void AddAttribute(DefenseAttribute inputAttr)
    {
        defense += inputAttr.defense;
        blockRate += inputAttr.blockRate;

        bluntDmgReduction += inputAttr.bluntDmgReduction;
        slashDmgReduction += inputAttr.slashDmgReduction;
        stabDmgReduction += inputAttr.stabDmgReduction;

        lightningRes += inputAttr.lightningRes;
        waterRes += inputAttr.waterRes;
        fireRes += inputAttr.fireRes;
        earthRes += inputAttr.earthRes;
        windRes += inputAttr.windRes;
        darkRes += inputAttr.darkRes;
        lightRes += inputAttr.lightRes;
    }
}

[System.Serializable]
public class BodyAttribute
{
    public float maxHealth;
    public float healthRegenRate;
    public float maxStamina;
    public float staminaRegenRate;
    public float moveSpeed;

    public void ResetAttribute()
    {
        maxHealth = 0;
        healthRegenRate = 0;
        maxStamina = 0;
        staminaRegenRate = 0;
        moveSpeed = 0;
    }

    public void AddAttribute(BodyAttribute inputAttr)
    {
        maxHealth += inputAttr.maxHealth;
        healthRegenRate += inputAttr.healthRegenRate;
        maxStamina += inputAttr.maxStamina;
        staminaRegenRate += inputAttr.staminaRegenRate;
        moveSpeed += inputAttr.moveSpeed;
    }
}
