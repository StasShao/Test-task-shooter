using UnityEngine;
public class resqueZoneMono : Resque
{
    [SerializeField] private GameObject[] _youWinObjects;

    protected override void OnTriggerEnter(Collider col)
    {
        ResqueNS.OntriggerEnter(col, _youWinObjects);
    }
  
}
