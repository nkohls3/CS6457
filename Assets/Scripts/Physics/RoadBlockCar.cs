using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockCar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            GetComponent<CarController>().RB = true;
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            GetComponent<CarController>().RB = false;
        }
    }
}
