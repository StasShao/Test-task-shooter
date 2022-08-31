using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMoverMono : SpawnPointMover
{
    [SerializeField] private Vector3 _coordinate;
    protected override void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            SpawnerPointMover.MovePoint(targetPoint, spawnpoint, _coordinate);
        }
    }
}
