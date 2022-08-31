using UnityEngine;

public abstract class DoorController : MonoBehaviour
{
    [SerializeField] protected HingeJoint doorHingeJoint;

    protected abstract void OnTriggerEnter(Collider col);
}
