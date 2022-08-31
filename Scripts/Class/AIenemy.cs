using UnityEngine;
using UnityEngine.AI;

public abstract class AIenemy : MonoBehaviour, IAI
{
    private AIEnemyNS _aIEnemyNS;
    [SerializeField]protected Transform _target;
    [SerializeField] protected NavMeshAgent _navMeshAgent;
    [SerializeField] protected Animator _anim;
    [SerializeField] protected AiSettings _aiSettings;
    [SerializeField] protected NavMeshPath _path;

    public bool ISATTACK { get; private set; }

    public bool ISFOLLOWTARGET { get; private set; }

    void Awake()
    {
        _aIEnemyNS = new AIEnemyNS(this, _target, _navMeshAgent, _anim, _aiSettings, _path);
    }

    
    void Update()
    {
        _aIEnemyNS.Tick();
        ListenerInput();
    }

    public void Attack(bool isAttack)
    {
        ISATTACK = isAttack;
    }

    public void FollowTarget(bool isFollowTqrget)
    {
        ISFOLLOWTARGET = isFollowTqrget;
    }
    protected abstract void ListenerInput();
}
