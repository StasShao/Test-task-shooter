using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCallerMono : PoolCaller
{
    [SerializeField] private Animator _gunAnim;
    [SerializeField] private int CurentBullets;
    [SerializeField] private GameObject[] _fireEffect;
    [SerializeField] private Transform _parentObjEffect;
    [SerializeField] protected AudioSource _asource;
    [SerializeField] protected AudioClip[] aclip;
    [SerializeField][Range(0,30)] private int MaxBullets;
    private bool isFirePause;
    private bool isReload;
    private bool isReloadSound;
    [SerializeField]private float ReloadTimer;
    [SerializeField]private float FirePauseTimer;
    [SerializeField] private float fireEffectTimer;
    [SerializeField] [Range(0.0f, 3.0f)] private float TimerReloadCoficient;
    [SerializeField] [Range(0.0f, 3.0f)] private float ReloadTimerCount;
    [SerializeField] [Range(0.0f, 3.0f)] private float FirePouseTimerCount;


    protected override void PoolFire()
    {
       
        if (isFirePause == true || isReload == true)
        {
            return;
        }

            if (Input.GetMouseButtonDown(0))
            {
                _asource.clip = aclip[0];
                _asource.PlayOneShot(aclip[0]);
                isFirePause = true;
                _fireEffect[0].SetActive(true);
                _fireEffect[1].SetActive(true);
            PoolCallerNS.PoolFire(ipool);
                _gunAnim.SetTrigger("Fire");
                CurentBullets--;
           
            }
    }

    protected override void PoolInst()
    {
      
    }
    private void ReloadGun()
    {
        
        ReloadTimer += TimerReloadCoficient * Time.deltaTime;
        if(ReloadTimer > 0.0f && ReloadTimer < 0.005f)
        {
            isReloadSound = true;
        }
        if(ReloadTimer >= ReloadTimerCount)
        {
            isReload = false;
            CurentBullets = MaxBullets;
            ReloadTimer = 0.0f;
        }
    }
    private void FirePause()
    {
        FirePauseTimer += TimerReloadCoficient * Time.deltaTime;
        if(FirePauseTimer >0.0f && FirePauseTimer < 0.1f)
        {
            _fireEffect[1].SetActive(false);
        }
        if (FirePauseTimer >= FirePouseTimerCount)
        {
            isFirePause = false;
            FirePauseTimer = 0.0f;
        }
    }

    protected override void YourEventStart()
    {
        CurentBullets = MaxBullets;
        isFirePause = true;
        isReload = true;
    }
    private void ReloadSound(bool play)
    {
        if(play)
        {
            _asource.clip = aclip[1];
            _asource.PlayOneShot(aclip[1]);
            isReloadSound = false;
        }
    }
    protected override void YourEventTick()
    {
        CurentBullets = Mathf.Clamp(CurentBullets, 0, 30);
       
        if (isFirePause)
        {
            FirePause();
        }
        if (isReload)
        {
            ReloadGun();
            ReloadSound(isReloadSound);
            _gunAnim.SetBool("Reload", true);
            
        }
        if (CurentBullets <= 0)
        {
            isReload = true;
        }
        if(!isReload)
        {
            _gunAnim.SetBool("Reload", false);
        }
        if(_fireEffect[0].activeInHierarchy)
        {
            fireEffectTimer += TimerReloadCoficient * Time.deltaTime;
            
            if(fireEffectTimer >= 0.2f)
            {
                _fireEffect[0].SetActive(false);
                fireEffectTimer = 0.0f;
            }
        }
        
    }
}
