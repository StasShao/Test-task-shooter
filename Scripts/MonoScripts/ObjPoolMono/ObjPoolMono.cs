using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolMono : ObjectPool
{
    [SerializeField] private bool GetInst;
   
    protected override void GetBulletPool()
    {
      
    }

    protected override void GetInstancePool()
    {
       
    }
}
