using UnityEngine;
using System.Collections;

public class CalculatePrisonerHP : CalculateHP
{
    private float curHP;
    private bool death;
    protected override void YourEventTick(bool isActive)
    {
        if(yes)
        {
            active = true;
            yes = false;
        }
        if(isActive)
        {
            if (HP <= 0)
            {
                SpawnerController.Inst(true);
                death = true;
                active = false;
            }
        }
        if(death)
        {
            _calcHpNS.ResetHp();
            StartCoroutine(Timer());
        }
   
    }

    protected override void YuorEventStart()
    {
        curHP = HP;
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        death = false;
        gameObject.SetActive(false);
    }
        
}
