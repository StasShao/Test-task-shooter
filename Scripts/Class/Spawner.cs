using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected IPool protIpool;
    [SerializeField] protected GameObject getIpoolobject;
    [SerializeField] protected Transform[] protTransforms;
   
    void Awake()
    {
        SpawnerController.Beginning(getIpoolobject, protIpool, protTransforms);
    }
    protected abstract void Ilistener();
    
    void Update()
    {
        Ilistener();
    }
}
