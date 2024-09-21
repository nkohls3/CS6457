using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorTrigger : MonoBehaviour
{
    public bool changeScene = false;
    public bool just_finished_tractor = false;

    void Start()
    {
        changeScene = false;
        just_finished_tractor = Singleton.Instance.just_finished_tractor;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            changeScene = true;
        }
    }


    void OnTriggerExit(Collider c)
    {
        changeScene = false;
        just_finished_tractor = false;
    }


}
