using UnityEngine;
[CreateAssetMenu(menuName ="ObjectPoolSettings",fileName ="ObjectPoolSettings/Data")]
public class PoolSettings : ScriptableObject
{
    [SerializeField] [Range(0, 100)] private int startPoolCapacity;
    [SerializeField] [Range(0, 100)] private int maxPoolCapacity;
    [SerializeField] [Range(0, 100)] private int spawninstanceCount;
    [SerializeField] [Range(0.0f, 2000.0f)] private float bulletPoolForceImpulce;
    [SerializeField] [Range(0.0f, 100.0f)] private float poolelEmentLifeTimer;
    [SerializeField] [Range(0.0f, 1.0f)] private float timerCoefficient;
    [SerializeField] private bool autoExpand;
    [SerializeField] private bool isInstancePool;
    [SerializeField] private bool isBulletPool;

    public int StartPoolCapacity { get { return startPoolCapacity; } }
    public int MaxPoolCapacity { get { return maxPoolCapacity; } }
    public int SpawnInstanceCount { get { return spawninstanceCount; } }
    public float BulletPoolForceImpulce { get { return bulletPoolForceImpulce; } }
    public float PoolLifeTimer { get { return poolelEmentLifeTimer;} }
    public float TimerCoefficient { get { return timerCoefficient; } }
    public bool AutoExpand { get { return autoExpand; } }
    public bool IsInstancePool { get { return isInstancePool; } }
    public bool IsBulletPool { get { return isBulletPool; } }
}
