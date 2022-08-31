using UnityEngine;
using UnityEngine.AI;

public class PrisonerListener : Listener
{
    [SerializeField]private float shower;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject[] _gos;
    [SerializeField] private AIenemy _aiEnemy;
    [SerializeField] private NavMeshAgent _navMesh;
    public override ICalculateHP ICALCUL(ICalculateHP iCalcul)
    {
        return iCalcul;
    }

    public override IHealth IHEALTH(IHealth iHealth)
    {
        return iHealth;
    }

    public override void SetMainHP(float setValue)
    {
        MAIN_HP = setValue;
    }

    public override void Shower()
    {
        _listenerNS.SetHpCALCUL();
        shower = MAIN_HP;
    }

    public override void YourEvent()
    {
       if(shower <= 0)
        {
            _aiEnemy.enabled = false;
            _navMesh.enabled = false;
            _anim.SetBool("Death", true);
            foreach (var item in _gos)
            {
                item.SetActive(false);
            }
        }else
        {
            _aiEnemy.enabled = true;
            _navMesh.enabled = true;
            _anim.SetBool("Death", false);
            foreach (var item in _gos)
            {
                item.SetActive(true);
            }
        }
    }

}
