using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPointMover : MonoBehaviour
{
    [SerializeField]protected Transform targetPoint;
    [SerializeField]protected Transform spawnpoint;


    protected abstract void OnTriggerEnter(Collider col);

}
