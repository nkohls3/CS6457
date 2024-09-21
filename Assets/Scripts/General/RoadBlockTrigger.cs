using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockTrigger : MonoBehaviour
{
    public bool roadBlockTrigger = false;
    public GameObject roadblock;

    void Start()
    {
        roadBlockTrigger = false;
    }

    void OnTriggerEnter(Collider c)
    {
        // Player has not collected friction upgrade
        if (c.gameObject.tag == "Player" && Singleton.Instance.friction == false)
        {
            roadBlockTrigger = true;
        }
        if (Singleton.Instance.friction == true)
        {
            // Deactivate wall
            roadblock.SetActive(false);

        }
    }


    void OnTriggerExit(Collider c)
    {
        roadBlockTrigger = false;
    }

}
