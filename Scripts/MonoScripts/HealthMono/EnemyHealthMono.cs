using UnityEngine;

public class EnemyHealthMono : Health
{
    private float curentHealthDamage;
    private float calculatedValue;
    [SerializeField] private GameObject HealthGO;
    private ICalculateHP _icalcHP;

    public override void DamVal(float value)
    {
        curentHealthDamage = (value * 0.2f);
    }

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
}
