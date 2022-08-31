using UnityEngine;
[CreateAssetMenu(menuName ="WeaponSettings",fileName ="WeaponSettings/Data")]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] [Range(0.0f, 1000.0f)] private float damage;
    [SerializeField] [Range(0.0f, 1000.0f)] private float pushForce;
    [SerializeField] private string targetTag;

    public float Damage { get { return damage; } }
    public float PushForce { get { return pushForce; } }
    public string TargtTag { get { return targetTag; } }

}
