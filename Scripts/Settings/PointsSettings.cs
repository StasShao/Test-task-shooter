using UnityEngine;
[CreateAssetMenu(menuName ="PointsSettings",fileName ="PointsSettings/Data")]
public class PointsSettings : ScriptableObject 
{
    [SerializeField] [Range(0, 100)] private int setPoints;
    [SerializeField] private string enterGameObjectTag;
    public int SetPoints { get { return setPoints; } }
    public string EnteringGameObjectTag { get { return enterGameObjectTag; } }
}
