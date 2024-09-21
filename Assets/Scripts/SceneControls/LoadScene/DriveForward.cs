using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveForward : MonoBehaviour
{
    public GameObject FrontLeftWheel;
    public GameObject FrontRightWheel;
    public GameObject RearLeftWheel;
    public GameObject RearRightWheel;

    Rigidbody car_Rigidbody;
    public float m_Thrust = 20000f;
    public ResetTrigger reset_trigger;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        car_Rigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        if (reset_trigger.resetCar)
        {
            FrontLeftWheel.GetComponent<TrailRenderer>().Clear();
            FrontRightWheel.GetComponent<TrailRenderer>().Clear();
            RearLeftWheel.GetComponent<TrailRenderer>().Clear();
            RearRightWheel.GetComponent<TrailRenderer>().Clear();

            FrontLeftWheel.GetComponent<TrailRenderer>().enabled = false;
            FrontRightWheel.GetComponent<TrailRenderer>().enabled = false;
            RearLeftWheel.GetComponent<TrailRenderer>().enabled = false;
            RearRightWheel.GetComponent<TrailRenderer>().enabled = false;

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().position = new Vector3(-40.0f,0.0f,10.0f);

            FrontLeftWheel.GetComponent<TrailRenderer>().enabled = true;
            FrontRightWheel.GetComponent<TrailRenderer>().enabled = true;
            RearLeftWheel.GetComponent<TrailRenderer>().enabled = true;
            RearRightWheel.GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            car_Rigidbody.AddForce(transform.forward * m_Thrust);
        }
    }
}


