using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolCaller : MonoBehaviour
{
    [SerializeField] protected GameObject ipoolGet;
    
    protected IPool ipool;

    private void Awake()
    {
        ipool = ipoolGet.GetComponent<IPool>();
       
    }
    private void Start()
    {
        PoolInst();
        YourEventStart();
    }
    private void Update()
    {
        PoolFire();
        YourEventTick();
    }
    protected abstract void PoolFire();
    protected abstract void PoolInst();
    protected abstract void YourEventStart();
    protected abstract void YourEventTick();

}
