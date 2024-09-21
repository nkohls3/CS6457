using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionPowerUp : MonoBehaviour
{
    public float frictionMultiplier;

    void OnTriggerEnter(Collider c) 
    {
        if (c.attachedRigidbody) {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();

            if (bc && !bc.friction) {
                Destroy(this.gameObject);

                GameObject current = c.attachedRigidbody.gameObject;
                List<WheelCollider> wheelColliders = new List<WheelCollider>();
                CarController cc = current.GetComponent<CarController>();
                current.GetComponentsInChildren(wheelColliders);
                Debug.Log(wheelColliders[0]);
                foreach (var wheel in wheelColliders)
                {
                    Debug.Log(wheel);
                    if(wheel) {
                            WheelFrictionCurve wfc;
                            wfc = wheel.sidewaysFriction;
                            wfc.extremumSlip *= frictionMultiplier;
                            wheel.sidewaysFriction = wfc;

                            wfc = wheel.forwardFriction;
                            wfc.extremumSlip *= frictionMultiplier;
                            wheel.forwardFriction = wfc;
                    }
                }

                bc.friction = true;
            }
        }
    }
}
