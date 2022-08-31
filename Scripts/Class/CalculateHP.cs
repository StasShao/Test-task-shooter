using UnityEngine;

public abstract class CalculateHP : MonoBehaviour, ICalculateHP
{
    protected CalculateHPNS _calcHpNS;
    [SerializeField]protected GameObject _body;
    [SerializeField]protected GameObject _head;
    [SerializeField]protected float ObjectHP;
    protected bool yes;
    protected ICalculateHP calculateHP;
    protected bool active;
   
    public float HP { get; protected set; }

    public void CAlculate(float hp)
    {
        HP = hp;
    }

    void Awake()
    {
        calculateHP = GetComponent<ICalculateHP>();
        _calcHpNS = new CalculateHPNS(this, _body, _head);
       
        ;    }
    void Start()
    {
        active = true;
        _calcHpNS.Strt();
        YuorEventStart();
    }

   
    void Update()
    {
        _calcHpNS.Tick();
        ObjectHP = HP;
        YourEventTick(active);
        if(gameObject.activeInHierarchy)
        {
            yes = true;
        }
    }
    protected abstract void YuorEventStart();
    protected abstract void YourEventTick(bool isActive);
   
}
