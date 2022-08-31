using UnityEngine;

public class DoorOpenerMono : DoorController
{
    [SerializeField]private MeshRenderer _meshRenderer;
    [SerializeField] private Material _setMaterial; 
    protected override void OnTriggerEnter(Collider col)
    {
       
            if (col.tag == "Player")
            {
                _meshRenderer.material = _setMaterial;
                DoorControllerNS.HingeJointDoorOpen(doorHingeJoint, true);
            }
      
    }
}
