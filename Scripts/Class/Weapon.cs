using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour,IHit
{
    protected WeaponNS _weaponNS;
    protected GameObject _enteringGO;
    [SerializeField]protected WeaponSettings _weaponSettings;
    protected bool isHead;
    protected float HP;
    public float DAMAGE { get; protected set; }
    private IHealth _ihealth;

    public abstract IHealth Ihealth(IHealth ihelth, float damage);
   

    void Awake()
    {
        _weaponNS = new WeaponNS(this,_enteringGO, _weaponSettings);
       
    }
    protected abstract void SetHp();

    protected abstract void OnCollisionEnter(Collision col);
    

}
