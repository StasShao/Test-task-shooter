using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthMono : Health
{
    private float DamageValue;
    public float PlayerHealth;
    [SerializeField] private GameObject HealthGO;
    [SerializeField] private Slider _sliderHP;
   

    protected override void DamageValueChange()
    {
       
        DamageValue = (HEALTH / 4); ;
       
    }

    protected override void ShowHP()
    {
        CurentHealth = HEALTH;
        _sliderHP.value = HEALTH;
    }

    public override void DamVal(float value)
    {
       
    }

    public override void TakeDamage(float damage)
    {
        damage = DamageValue;
        HEALTH -= damage;
    }

}
