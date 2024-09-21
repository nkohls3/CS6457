using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftTrigger : MonoBehaviour
{
    public bool changeScene = false;

    void Start()
    {
        changeScene = false;
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
    }
}
