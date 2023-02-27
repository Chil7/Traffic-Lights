using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class TrafficLight : MonoBehaviour
{
    [Range(0, 10)]
    public int waitingCars;

    [SerializeField] private string lightName;

    public MeshRenderer Renderer { get; private set; }

    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        StateMachine = new StateMachine();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.increaseCarsWaitingEvent += CarWaiting;

        waitingCars = 0;

        StateMachine.SetState(new RedLight(this));
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingCars == 0)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID == TrafficLightsID.green)
            {
                StateMachine.SetState(new AmberLight(this));
            }
        }
        else if (waitingCars >= 5)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID != TrafficLightsID.green)
            {
                StateMachine.SetState(new GreenLight(this));
            }
        }

        StateMachine.OnUpdate();
    }

    public void ChangeLight(int _lightID)
    {
        if (_lightID == 0)
        {
            StateMachine.SetState(new GreenLight(this));
        }
        else if (_lightID == 1)
        {
            StateMachine.SetState(new AmberLight(this));
        }
        else if (_lightID == 2)
        {
            StateMachine.SetState(new RedLight(this));
        }
    }

    public void CarWaiting(int _carAmount, string _lightName)
    {
        if (_lightName == lightName)
        {
            waitingCars += _carAmount;
        }
        
    }

    public enum TrafficLightsID { green = 0, orange = 1, red = 2 }

    public abstract class TrafficLightState : IState
    {
        public TrafficLightsID ID { get; protected set; }

        protected TrafficLight instance;

        public TrafficLightState(TrafficLight _instance)
        {
            instance = _instance;
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnExit()
        {
            
        }
    }

    public class GreenLight : TrafficLightState
    {
        public GreenLight(TrafficLight _instance) : base(_instance) 
        {
            ID = TrafficLightsID.green;
        }

        public override void OnEnter() 
        {
            instance.Renderer.material.color = Color.green;
            Debug.Log("Green");
        }

        public override void OnUpdate()
        {
            Debug.Log("is Green");
        }

        public override void OnExit()
        {
            Debug.Log("no Green");
        }
    }

    public class AmberLight : TrafficLightState
    {
        public float time = 3f;
        public float timer = 0f;

        public AmberLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightsID.orange;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.yellow;
            Debug.Log("Orange");
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;

            if (timer >= time) 
            {
                instance.StateMachine.SetState(new RedLight(instance));
            }
            Debug.Log("is Orange");
        }

        public override void OnExit()
        {
            Debug.Log("no Orange");
        }
    }

    public class RedLight : TrafficLightState
    {
        public RedLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightsID.red;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.red;
            Debug.Log("Red");
        }

        public override void OnUpdate()
        {

            Debug.Log("is Red");
        }

        public override void OnExit()
        {
            Debug.Log("no Red");
        }
    }
}
