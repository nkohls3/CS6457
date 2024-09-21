using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSmokeTrigger : MonoBehaviour
{
    public bool smokeOn = true;
    public GameObject car_smoke;

    void Start()
    {
        smokeOn = true;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            car_smoke.SetActive(false);
            smokeOn = false;
        }
    }


    void OnTriggerExit(Collider c)
    {
        smokeOn = false;
    }

}
