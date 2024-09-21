using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetTrigger : MonoBehaviour
{
    public bool resetCar = false;

    void Start()
    {
        resetCar = false;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            // Reset the position of the car and velocity
            resetCar = true;

        }
    }


    void OnTriggerExit(Collider c)
    {
        resetCar = false;
    }

}
