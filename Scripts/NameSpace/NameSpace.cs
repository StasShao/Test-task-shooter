using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NavmeshBuilder = UnityEngine.AI.NavMeshBuilder;

public class MainMenuNS 
{
    private IMainMenu _imainMenu;
    private MainMenu _mainMenu;
    public MainMenuNS(MainMenu mainMenu)
    {
        _mainMenu = mainMenu;
        _imainMenu = _mainMenu.GetComponent<IMainMenu>();
        _imainMenu.SoundVolumeSwitch(true);
    }
    private void EnterGameScene()
    {
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void SoundVolumeSwitcher(bool on_off)
    {
        if(on_off)
        {
            AudioListener.volume = 1;
        }else
        {
            AudioListener.volume = 0;
        }

    }
    private void IListener()
    {
        if(_imainMenu.ISGAME)
        {
            EnterGameScene();
        }
        if (_imainMenu.ISEXIT)
        {
            ExitGame();
        }
        if (_imainMenu.ISSOUND)
        {
            SoundVolumeSwitcher(true);
        }else
        {
            SoundVolumeSwitcher(false);
        }
    }
    public void Tick()
    {
        IListener();
    }

}
//=================================================================================================================================================
public class ControllerFPSControllerNS
{
    private Rigidbody _fpsRb;
    private Transform _camtransform;
    private ControllerSettings _controllerSettings;
    private Icontroller _icontroller;
    private bool isGrounded;
    public ControllerFPSControllerNS(Rigidbody fpsRb, Transform camtransform, ControllerSettings controllerSettings)
    {
        _camtransform = camtransform;
        _fpsRb = fpsRb;
        _controllerSettings = controllerSettings;
        _icontroller = _fpsRb.gameObject.GetComponent<Icontroller>();
        isGrounded = true;
    }
    private void Movement(bool isGround)
    {
        if(isGround)
        {
            _fpsRb.drag = 1.0f;
            _fpsRb.AddForce(_fpsRb.transform.forward * _icontroller.MOVE * _controllerSettings.MoveForce, ForceMode.Force);
            _fpsRb.AddForce(_fpsRb.transform.right * _icontroller.STRAFE * _controllerSettings.StrafeForce, ForceMode.Force);
            if (_icontroller.JUMP)
            {
                _fpsRb.AddForce(_fpsRb.transform.up * _controllerSettings.JumpForce, ForceMode.Impulse);
                _icontroller.Jump(false);
            }
        }else
        {
            _fpsRb.drag = 0.0f;
        }
        
    }
    private void GroundCheck()
    {
        Ray ray = new Ray(_fpsRb.transform.position, -_fpsRb.transform.up * _controllerSettings.RayGroundCheckDist);
        Debug.DrawRay(ray.origin, ray.direction * _controllerSettings.RayGroundCheckDist, _controllerSettings.RayGrCheckColor);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,_controllerSettings.RayGroundCheckDist,_controllerSettings.RayGrCheckMask))
        {
           
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }
    }
    private void MouseLook()
    {
        _fpsRb.transform.Rotate(0, _icontroller.MOUSE_X * _controllerSettings.RotateForce, 0);
        _camtransform.Rotate(-_icontroller.MOUSE_Y * _controllerSettings.RotateForce, 0, 0);
    }
    public void FixTick()
    {
        GroundCheck();
        Movement(isGrounded);

    }
    public void Tick()
    {
       
        MouseLook();
    }
}
//=================================================================================================================================================
public class ObjetPoolNS 
{
    private ObjectPool _objPool;
    private Transform[] _coorditeTransforms;
    private Transform _container;
    private List<PoolPrefab> _objPooList;
    private PoolSettings _poolSettings;
    private List<float> _elementTimer;
    private float tmer;
    private IPool _ipool;
    public ObjetPoolNS(ObjectPool objPool, List<PoolPrefab> objPooList, PoolSettings poolSettings, List<float> elementTimer, Transform[] coorditeTransforms, Transform container)
    {
        _container = container;
        _coorditeTransforms = coorditeTransforms;
        _poolSettings = poolSettings;
        _objPool = objPool;
        _ipool = _objPool.GetComponent<IPool>();
        _objPooList = objPooList;
        _elementTimer = elementTimer;
      
    }
    private PoolPrefab PoolCreate(bool activity)
    {
       return  _objPool.CreatePool(activity);
    }
    private bool TryGetElement(out PoolPrefab pPrefab)
    {
           foreach(PoolPrefab item in _objPooList)
            {
              if (!item.gameObject.activeInHierarchy)
              {
                pPrefab = item;
              
                pPrefab.gameObject.SetActive(true);
                return true;
              }
            }
            pPrefab = null;
            return false;
    }
    private PoolPrefab GetFreeElement(List<PoolPrefab> poolObjcts)
    {
       
        if(TryGetElement(out var pPrefab))
        {
            if(_poolSettings.IsBulletPool)
            {
                _objPool.Rbs(pPrefab._rb);
                pPrefab.transform.parent = null;
            }
           
            if(_poolSettings.IsInstancePool)
            {
                    pPrefab.transform.parent = null;
                    _objPool.GetGameobject(pPrefab.gameObject);
                    _objPool.Instance(_coorditeTransforms[0].position);
            
            }
            return pPrefab;
  
       
        }
        if(_poolSettings.AutoExpand & _objPooList.Count < _poolSettings.MaxPoolCapacity)
        {
           
            return PoolCreate(true);
        }

        ElementsTimer(_poolSettings.IsBulletPool);
        throw new System.Exception("Pool is over !!!");
    }
    private void ElementsTimer(bool isActive)
    {
       if(isActive)
        {
            for (int i = 0; i < _objPooList.Count; i++)
            {
                if (_objPooList[i].gameObject.activeInHierarchy)
                {
                    _elementTimer[i] += _poolSettings.TimerCoefficient * Time.deltaTime;
                    if (_elementTimer[i] >= _poolSettings.PoolLifeTimer)
                    {
                        _elementTimer[i] = 0.0f;
                        _objPooList[i].gameObject.SetActive(false);
                        _objPooList[i].transform.parent = _container;
                    }
                }
            }
        }
     
    }
   private void BulletPoolFire(bool isBulletPool)
    {
        if(isBulletPool)
        {
            GetFreeElement(_objPooList);
            if (_ipool.RB != null)
            {
                _ipool.RB.angularVelocity = Vector3.zero;
                _ipool.RB.inertiaTensor = Vector3.zero;
                _ipool.RB.velocity = Vector3.zero;
                _ipool.RB.inertiaTensorRotation = Quaternion.Euler(0, 0, 0);
                _ipool.RB.transform.position = _objPool.gameObject.transform.position;
                _ipool.RB.transform.rotation = _objPool.gameObject.transform.rotation;
                _ipool.RB.AddForce(_ipool.RB.transform.forward * _poolSettings.BulletPoolForceImpulce, ForceMode.Impulse);
            }
        }
       
        _ipool.Fire(false);
    }
   
    private void Instancepool(bool isInstpool)
    {
        if(isInstpool)
        {
            for (int i = 0; i < _poolSettings.SpawnInstanceCount; i++)
            {
                GameObject go = GetFreeElement(_objPooList).gameObject;
                go.SetActive(true);
                if (_ipool.GAMEOBJECT != null)
                {
                    _ipool.GAMEOBJECT.transform.position = _coorditeTransforms[0].position;
                }
            } 
            SpawnerController.Inst(false);
            _ipool.Inst(false);
        }
 
    }
    private void Ilistener()
    {
      if(_ipool.FIRE)
        {
            BulletPoolFire(_poolSettings.IsBulletPool);
        }
        if(_ipool.INSTANCE)
        {
            Instancepool(_poolSettings.IsInstancePool);
        }
    }
    public IPool IpoolCommand(IPool ipool)
    {
       return ipool;
    }
   
   
    public void Tick()
    {
        Ilistener();
        ElementsTimer(_poolSettings.IsBulletPool);
    }
    public void Strt()
    {
        for (int i = 0; i < _poolSettings.StartPoolCapacity; i++)
        {
            PoolCreate(false);
        }
    }

}
//=================================================================================================================================================
public class AIEnemyNS
{
    private AIenemy _aiEnemy;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private Animator _anim;
    private AiSettings _aiSettings;
    private IAI _iAI;
    private float dist;
    private NavMeshData _navMeshData;
    private List<NavMeshBuildSource> Sources = new List<NavMeshBuildSource>();
    private NavMeshPath _path;
    private NavMeshBuildSourceShape build;
    public AIEnemyNS(AIenemy aiEnemy, Transform target, NavMeshAgent navMeshAgent, Animator anim, AiSettings aiSettings, NavMeshPath path)
    {
        _path = path;
        _aiSettings = aiSettings;
        _aiEnemy = aiEnemy;
        _target = GameObject.Find(_aiSettings.TargetName).transform;
        target = _target;
        _navMeshAgent = navMeshAgent;
        _anim = anim;
        _iAI = _aiEnemy.GetComponent<IAI>();
        _path = new NavMeshPath();
        _navMeshData = new NavMeshData();
        _navMeshAgent.avoidancePriority = _navMeshAgent.avoidancePriority + Random.Range(1,50);

    }
    private void FollowEnemyTarget()
    {
        if(_navMeshAgent != null)
        {
            
            _navMeshAgent.SetDestination(_target.position);
        }
       
       
        if (_navMeshAgent.desiredVelocity.sqrMagnitude > 0)
        {
            _anim.SetFloat("Walk", 1);
        }
       else 
        {
            _anim.SetFloat("Walk", 0);
        }
    }
    private void AttackTargert()
    {
        dist = Vector3.Distance(_navMeshAgent.transform.position, _target.position);
        if(dist <= _aiSettings.StopingDistNav&& _target != null)
        {
            
            _anim.SetTrigger("Attack");
        }else
        {
            if(_target != null)
            {
               
            }
           
        }
        _iAI.Attack(false);
    }
    private void Ilistener()
    {
        AttackTargert();
        if (_iAI.ISFOLLOWTARGET)
        {
            FollowEnemyTarget();
        }
    
    }
    public void Tick()
    {
        Ilistener();
    }
}
//=================================================================================================================================================
public class WeaponNS
{
    private Weapon _weapon;
    private GameObject _enteringsGO;
    private WeaponSettings _weaponSettings;
    private IHealth _ihelth;
    private Rigidbody rb;
    public WeaponNS(Weapon weapon, GameObject enteringsGO, WeaponSettings weaponSettings)
    {
        _weaponSettings = weaponSettings;
        _weapon = weapon;
        _enteringsGO = enteringsGO;
    }
    private void Damage()
    {
       if(_ihelth != null)
        {
            _weapon.Ihealth(_ihelth, _weaponSettings.Damage);
        }
           
  
        if(rb != null)
        {
            rb.AddForce(-rb.transform.forward * _weaponSettings.PushForce, ForceMode.Impulse);
        }
       
    }
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == _weaponSettings.TargtTag)
        {
            if(_enteringsGO != col.gameObject)
            {
                _enteringsGO = col.gameObject;
                rb = col.rigidbody;
                _ihelth = col.gameObject.GetComponent<IHealth>();
                Damage();
            }else
            {
                
                Damage();
            }
        }

    }

}
//=================================================================================================================================================
public class CalculateHPNS
{
    private CalculateHP _calcHP;
    private IHealth[] _ihealthParts;
    private GameObject _body;
    private GameObject _head;
    private float result;
    private bool isDones;
    public CalculateHPNS(CalculateHP calcHP, GameObject body, GameObject head)
    {
        _calcHP = calcHP;
        _body = body;
        _head = head;
        _ihealthParts = new IHealth[2];
        _ihealthParts[0] = _body.GetComponent<IHealth>();
        _ihealthParts[1] = _head.GetComponent<IHealth>();
        isDones = true;
    }
    public void Calcul(bool isDone)
    {
       if(isDone)
        {
            result = _ihealthParts[0].HEALTH + _ihealthParts[1].HEALTH;
            _calcHP.CAlculate(result);
            for (int i = 0; i < _ihealthParts.LongLength; i++)
            {
                _ihealthParts[i].DamVal(result);
            }
             
        }
              
    }
    public void Strt()
    {
        Calcul(isDones); ;
    }
    private void ShowCurentHP()
    {
         result = _ihealthParts[0].HEALTH + _ihealthParts[1].HEALTH;
        _calcHP.CAlculate(result);
    }
    public void Tick()
    {
        ShowCurentHP();
    }
    public void ResetHp()
    {
        foreach (var item in _ihealthParts)
        {
            item.SetStartHealth(1000);
        }
    }

}
//=================================================================================================================================================
public class PointsAdd_NS
{
    private Points _points;
    private Ipoints _ipoints;
    private PointsSettings _pointsSettings;
    public PointsAdd_NS(Points points, PointsSettings pointsSettings)
    {
        _points = points;
        _pointsSettings = pointsSettings;
        _ipoints = _points.GetComponent<Ipoints>();
       
    }
    private void GetPoints()
    {
        _ipoints.SetPoints(_pointsSettings.SetPoints);
    }
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == _pointsSettings.EnteringGameObjectTag)
        {
            GetPoints();
        }
    }
}
//=================================================================================================================================================
public class ListenerIeventsNS
{
    private Listener _listener;
    private IListener _ilistener;
    private CalculateHP _calculateHP;
    private Health _helth;
    private ICalculateHP _iCalcul;
    private IHealth _ihealth;
    public ListenerIeventsNS(Listener listener, CalculateHP calculateHP, Health helth)
    {
        _listener = listener;
        _calculateHP = calculateHP;
        _helth = helth;
        _ilistener = _listener.GetComponent<IListener>();
        if (_calculateHP != null)
        {
            _iCalcul = _calculateHP.GetComponent<ICalculateHP>();
        }
        if (_helth != null)
        {
            _ihealth = _helth.GetComponent<IHealth>();
        }
    }
    private void GetHelth()
    {
        if(_ihealth != null)
        {
            _listener.IHEALTH(_ihealth);
        }
       
    }
    private void GetCalculHealth()
    {
        if (_iCalcul != null)
        {
            _ilistener.ICALCUL(_iCalcul);
        }
       
    }
    public void SetHPHEALTH()
    {
        if (_ihealth != null)
        {
            _listener.SetMainHP(_ihealth.HEALTH);
        }
       
    }
    public void SetHpCALCUL()
    {
        if (_iCalcul != null)
        {
            _listener.SetMainHP(_iCalcul.HP);
        }
       
    }
    public void GetSetAll()
    {
        GetHelth();
        GetCalculHealth();
       
    }

}
//=================================================================================================================================================
public static class StaticPointsCalculater
{
    public static float CurentPoints;
    public static float BestPoints;
    public static Text _curentPointsText;
    public static Text _besttPointsText;

    public static void Begin()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestPoints = PlayerPrefs.GetFloat("BestScore");
        }
    }


    public static void ConvertText(Text curent, Text best)
    {
        curent.text = CurentPoints.ToString(); ;
        best.text = BestPoints.ToString(); ;
        if (CurentPoints >= BestPoints)
        {
            BestPoints = CurentPoints;
            PlayerPrefs.SetFloat("BestScore", BestPoints);
        }
    }
}
//=================================================================================================================================================
public static class SpawnerController
{
    public static bool ISINST;
    public static IPool IpoolStatic;
    public static Transform[] _positionsInstance;
    public static void Inst(bool isInstance)
    {
        ISINST = isInstance;
    }
    public static void Beginning(GameObject ipoolGettingObject,IPool ipool, Transform[] positionsInstance)
    {
        ipool = ipoolGettingObject.GetComponent<IPool>();
        IpoolStatic = ipool;
        _positionsInstance = new Transform[positionsInstance.Length];
        _positionsInstance = positionsInstance;
        GetInst(IpoolStatic);
    }
    public static IPool GetInst(IPool ipool)
    {

        return ipool;
        
    }
    
}
//=================================================================================================================================================
public static class SpawnerPointMover
{
   public static Vector3 MovePoint(Transform targetpoint,Transform spawnPoint,Vector3 coordinate)
    {
        spawnPoint.position = targetpoint.position;
        coordinate = spawnPoint.position;
        return coordinate;

    }

}
//=================================================================================================================================================
public static class DoorControllerNS
{
    public static HingeJoint HingeJointDoorOpen(HingeJoint hj,bool open_close)
    {
        hj.useMotor = open_close;
        return hj;

    }
}
//=================================================================================================================================================
public static class PoolCallerNS
{
    public static IPool PoolFire(IPool ipool)
    {
        ipool.Fire(true);
        return ipool;
    }
    public static IPool PoolInstantiate(IPool ipool)
    {
        ipool.Inst(true);
        return ipool;
    }
}
//=================================================================================================================================================
public static class EffectSwitcherNS
{
    public static float Timer;
    public static void DesableEffect(GameObject element)
    {
        if(element.activeInHierarchy)
        {
            Timer += 0.2f * Time.deltaTime;
            if(Timer >= 0.3f)
            {
                Timer = 0.0f;
                element.SetActive(false);
            }
        }
    }
}
//=================================================================================================================================================
public static class ResqueNS
{
    public static void Begin()
    {
        Time.timeScale = 1.0f;
    }
    public static void OntriggerEnter(Collider col,GameObject[] _youWinTexts)
    {
        if(col.tag =="Player")
        {
            foreach (var item in _youWinTexts)
            {
                item.SetActive(true);
               
            }
            Time.timeScale = 0.1f;
        }
    }

}
//=================================================================================================================================================





