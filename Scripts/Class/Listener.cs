using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Listener : MonoBehaviour, IListener
{
    protected ListenerIeventsNS _listenerNS;
    [SerializeField]protected CalculateHP _calculateHP;
    [SerializeField]protected Health _helth;

    public float MAIN_HP { get; protected set; }

    public abstract ICalculateHP ICALCUL(ICalculateHP iCalcul);


    public abstract IHealth IHEALTH(IHealth iHealth);


    public abstract void SetMainHP(float setValue);
    public abstract void Shower();

    public abstract void YourEvent();
  

    void Awake()
    {
        _listenerNS = new ListenerIeventsNS(this, _calculateHP, _helth);
    }
    void Start()
    {
        _listenerNS.GetSetAll();
    }

   
    void Update()
    {
        Shower();
        YourEvent();
    }
}
