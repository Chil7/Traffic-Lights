using UnityEngine;
using UnityEngine.AI;
using FSM2;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    
    [SerializeField] private GameObject navTarget;
    [SerializeField] private float stoppingDist;

    public StateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        StateMachine = new StateMachine();

        if(!TryGetComponent<NavMeshAgent>(out agent))
        {
            Debug.LogError("This object needs an object agent attached to it");
        }

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
            //set the agent to stopped
            instance.agent.isStopped = true;
        }

        public override void OnUpdate()
        {
            //update the position of the target object and move towads it
            if (Vector3.Distance(instance.transform.position, instance.navTarget.transform.position) > instance.stoppingDist)
            {
                instance.agent.SetDestination(instance.navTarget.transform.position);
            }
            else
            {
                //Set state to Idle
                instance.StateMachine.SetState(new IdleState(instance));
            }
        }
    }

    public class IdleState : EnemyMoveState
    {
        public IdleState(EnemyAI _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            instance.agent.isStopped = true;
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(instance.transform.position, instance.navTarget.transform.position) > instance.stoppingDist)
            {
                //seitch to movestate
                instance.StateMachine.SetState(new MoveState(instance));
            }
           
        }

        public override void OnExit()
        {
            
        }
    }
}
