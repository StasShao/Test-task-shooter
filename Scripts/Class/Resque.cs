using UnityEngine;

public abstract class Resque : MonoBehaviour
{
    private void Start()
    {
        ResqueNS.Begin();
    }

    protected abstract void OnTriggerEnter(Collider col); 
}
