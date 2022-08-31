using UnityEngine;

public class PrisonerWeapontrigger : Weapon
{
    public override IHealth Ihealth(IHealth ihelth, float damage)
    {
        ihelth.TakeDamage(damage);
        return ihelth;
    }

    protected override void OnCollisionEnter(Collision col)
    {
        _weaponNS.OnCollisionEnter(col);
    }

    protected override void SetHp()
    {
        
    }
}
