using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstPoolCallerMono : PoolCaller
{
    protected override void PoolFire()
    {
       
    }

    protected override void PoolInst()
    {
        ipool.Inst(true);
    }

    protected override void YourEventStart()
    {
        
    }

    protected override void YourEventTick()
    {
        
    }
}
