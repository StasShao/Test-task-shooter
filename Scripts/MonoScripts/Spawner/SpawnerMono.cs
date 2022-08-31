using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMono : Spawner
{
    [SerializeField] private int SpawnCount;
    private IPool _ipool;
    protected override void Ilistener()
    {
      if(SpawnerController.ISINST)
        {
          
          
                _ipool = SpawnerController.GetInst(SpawnerController.IpoolStatic);
                _ipool.Inst(true);
         
            
           

        }
    }
}
