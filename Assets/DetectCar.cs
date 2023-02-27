using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCar : MonoBehaviour
{
    public string lightName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "car")
        {
            //invoke increase cars waiting event
            EventManager.increaseCarsWaitingEvent(5, lightName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
            //invoke increase cars waiting event
            EventManager.increaseCarsWaitingEvent(-5, lightName);
        }
    }
}
