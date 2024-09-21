using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTutorialTrigger : MonoBehaviour
{
    public StopSmokeTrigger stop_smoke;
    public bool changeScene = false;

    void Start()
    {
        changeScene = false;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && stop_smoke.smokeOn == false)
        {
            changeScene = true;
        }
    }


    void OnTriggerExit(Collider c)
    {
        changeScene = false;
    }

}
