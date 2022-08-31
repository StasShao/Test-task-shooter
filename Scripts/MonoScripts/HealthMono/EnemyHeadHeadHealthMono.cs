using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadHeadHealthMono : Health
{
    private float calculatedValue;
    private float curentHealthDamage;
    [SerializeField] private GameObject HealthGO;
    private ICalculateHP _icalcHP;
    public override void TakeDamage(float headDamage)
    {

        headDamage = curentHealthDamage;
        HEALTH -= headDamage;

    }

    protected override void DamageValueChange()
    {
      
    }

    protected override void ShowHP()
    {
       
        CurentHealth = HEALTH;
       
    }

    public override void DamVal(float value)
    {
        curentHealthDamage = (value * 0.5f);
    }
}
