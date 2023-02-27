using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    void Start()
    {
        if (Instance== null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("no more, one enough");
        }
    }

    public delegate void LoseHealth(float _amount);
    public static LoseHealth loseHealthEvent;

    public delegate void GainHealth(float _amount);
    public static GainHealth gainHealthEvent;

    public delegate void ChangeLight(int _lightID, string _lightname);
    public static ChangeLight changeLightEvent;

    public delegate void IncreaseCarsWaiting(int _amount, string _lightname);
    public static IncreaseCarsWaiting increaseCarsWaitingEvent;
}
