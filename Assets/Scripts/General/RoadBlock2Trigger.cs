using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock2Trigger : MonoBehaviour
{
    public bool roadBlockTrigger = false;

    void Start()
    {
        roadBlockTrigger = false;
    }

    void OnTriggerEnter(Collider c)
    {
        // Player has not collected friction upgrade
        if (c.gameObject.tag == "Player" && Singleton.Instance.jump == false)
        {
            roadBlockTrigger = true;
        }
    }


    void OnTriggerExit(Collider c)
    {
        roadBlockTrigger = false;
    }

}
