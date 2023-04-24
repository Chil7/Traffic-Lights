using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using FSM2;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    
    [SerializeField] private GameObject navTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private float stoppingDist;
    [SerializeField] private float detectionDist;

    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;

    private Animator animator;

    public StateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        StateMachine = new StateMachine();

        if(!TryGetComponent<NavMeshAgent>(out agent))
        {
            Debug.LogError("This object needs an object agent attached to it");
        }

        animator = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
        StateMachine.SetState(new IdleState(this));
        agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.OnUpdate();
    }

    public abstract class EnemyMoveState : IState
    {
        protected EnemyAI instance;

        public EnemyMoveState(EnemyAI _instance)
        {
            instance = _instance;
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExit()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }
    }

    public class MoveState : EnemyMoveState
    {
        public MoveState(EnemyAI _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Move");
            instance.animator.ResetTrigger("IsWalk");
            instance.agent.speed = instance.walkSpeed;
            //set the agent to stopped
            instance.agent.isStopped = true;
        }

        public override void OnUpdate()
        {
            //update the position of the target object and move towads it
            if (Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDist)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if (Vector3.Distance(instance.transform.position, instance.navTarget.transform.position) > instance.stoppingDist)
            {
                instance.agent.SetDestination(instance.navTarget.transform.position);
            }
            else
            {
                //Set state to Idle
                instance.StateMachine.SetState(new IdleState(instance));
            }
        }

        public override void OnExit()
        {
            instance.animator.ResetTrigger("IsWalk");
        }
    }

    public class IdleState : EnemyMoveState
    {
        public IdleState(EnemyAI _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Idle");
            instance.animator.SetTrigger("IsIdle");
            instance.agent.isStopped = true;
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDist) 
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if (Vector3.Distance(instance.transform.position, instance.navTarget.transform.position) > instance.stoppingDist)
            {
                //seitch to movestate
                instance.StateMachine.SetState(new MoveState(instance));
            }

           
        }

        public override void OnExit()
        {
            instance.animator.ResetTrigger("IsIdle");
        }
    }

    public class ChaseState : EnemyMoveState
    {
        public ChaseState(EnemyAI _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Chase");
            instance.animator.SetTrigger("IsRun");
            instance.agent.speed = instance.runSpeed;
            instance.agent.isStopped = false;
        }

        public override void OnUpdate()
        {
            if(Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDist)
            {
                instance.agent.SetDestination(instance.player.transform.position);
            }
            else
            {
                instance.StateMachine.SetState(new IdleState(instance));
            }
        }

        public override void OnExit()
        {
            instance.animator.ResetTrigger("IsRun");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDist);
    }
}
