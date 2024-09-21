using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{

    void OnTriggerEnter(Collider c) 
    {
        if (c.attachedRigidbody) {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();

            if (bc && !bc.speed) {
                Destroy(this.gameObject);

                GameObject current = c.attachedRigidbody.gameObject;
                CarController cc = current.GetComponent<CarController>();
                if(cc) {
                    cc.motorForce = 2000;
                }

                bc.speed = true;
            }
        }
    }
}
