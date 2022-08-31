using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour, IPool
{
    protected ObjetPoolNS _objPoolNS;
    [SerializeField]protected PoolPrefab _prefab;
    [SerializeField]protected Transform _container;
    [SerializeField]protected List<PoolPrefab> _objPooList;
    [SerializeField]protected PoolSettings _poolSettings;
    [SerializeField]protected List<float> _elementTimer;
    [SerializeField]protected Transform[] _coorditeTransforms;
    protected Rigidbody _rb;
    protected GameObject _gameObject;
    protected IPool _ipool;
    private float _freeFloat;

    public bool INSTANCE { get; private set; }

    public Rigidbody RB { get; private set; }

    public GameObject GAMEOBJECT { get; private set; }

    public Vector3 POSITIONCOORDINATE { get; private set; }

    public bool FIRE { get; private set; }

    void Awake()
    {
        _ipool = GetComponent<IPool>();
        _objPooList = new List<PoolPrefab>(_poolSettings.MaxPoolCapacity);
        _elementTimer = new List<float>(_poolSettings.StartPoolCapacity);
        _objPoolNS = new ObjetPoolNS(this , _objPooList, _poolSettings, _elementTimer, _coorditeTransforms, _container);
    }
    private void Start()
    {
        _objPoolNS.Strt();
        GetInstancePool();
    }

    void Update()
    {
        _objPoolNS.Tick();
        GetBulletPool();
    }
    public PoolPrefab CreatePool(bool isActivaeByDefoult)
    {
        var createdObj = Instantiate(_prefab, _container.position, _container.rotation,_container);
        _objPooList.Add(createdObj);
        _elementTimer.Add(_freeFloat);
        createdObj.gameObject.SetActive(isActivaeByDefoult);
        return createdObj;
       
    }

    public GameObject GetGameobject(GameObject gameobject)
    {
        GAMEOBJECT = gameobject;
        return GAMEOBJECT;
    }

    public void Instance(Vector3 positionCoordinate)
    {
        POSITIONCOORDINATE = positionCoordinate;
     
    }
    protected abstract void GetBulletPool();
    protected abstract void GetInstancePool();

    public void Fire(bool fire)
    {
        FIRE = fire;
    }

    public Rigidbody Rbs(Rigidbody rb)
    {
        RB = rb;
        return RB;
    }

    public void Inst(bool inst)
    {
        INSTANCE = inst;
    }
}
