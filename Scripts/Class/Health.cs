using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour,IHealth
{
    [SerializeField][Range(50.0f,1000.0f)] protected float SetHEalth;
    
    public float HEALTH { get; protected set; }
    [SerializeField] protected float CurentHealth;

    public void SetStartHealth(float startHealth)
    {

        HEALTH = startHealth;
       
    }
    void Awake()
    {
        SetStartHealth(SetHEalth);
        DamageValueChange();
    }
   
    private void Update()
    {
        ShowHP();
    }
    public void ResetHealth()
    {
        SetStartHealth(SetHEalth);
    }
    protected abstract void DamageValueChange();
    protected abstract void ShowHP();

    public abstract void TakeDamage(float damage);

    public abstract void DamVal(float value);
   
}
