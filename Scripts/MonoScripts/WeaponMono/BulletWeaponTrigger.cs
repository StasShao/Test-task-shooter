using UnityEngine;

public class BulletWeaponTrigger : Weapon
{
    [SerializeField]private bool isHeaddd;
    [SerializeField] private Transform _targetEffect;
    public override IHealth Ihealth(IHealth ihelth, float damage)
    {
           ihelth.TakeDamage(damage);
           return ihelth;
    }

    protected override void OnCollisionEnter(Collision col)
    {

        _weaponNS.OnCollisionEnter(col);
        if (col.gameObject.tag == _weaponSettings.TargtTag)
        {
            if(_targetEffect != null)
            {
                _targetEffect.parent = null;
                _targetEffect.position = col.contacts[0].point;
                _targetEffect.rotation = col.gameObject.transform.rotation;
                _targetEffect.gameObject.SetActive(true);
            }

            gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }

    protected override void SetHp()
    {
       
    }
}
