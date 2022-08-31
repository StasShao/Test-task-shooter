using UnityEngine;
[CreateAssetMenu(menuName ="AiSettings",fileName ="AiSettings/Data")]
public class AiSettings : ScriptableObject
{
    [SerializeField] [Range(0.0f, 100.0f)] private float stopingDistNav;
    [SerializeField] [Range(0.0f, 100.0f)] private float navSpeed;
    [SerializeField] private string targetName;
    public float StopingDistNav { get { return stopingDistNav; } }
    public float NavSpeed { get { return navSpeed; } }
    public string TargetName { get { return targetName; } }
}
