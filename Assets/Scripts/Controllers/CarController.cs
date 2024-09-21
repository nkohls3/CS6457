using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private Scene currentScene;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private bool isJumping;

    private bool rb = false;
    public bool RB {
        get {return rb;}
        set {rb = value;}
    }

    private Rigidbody carBody;

    [SerializeField] public float motorForce;
    [SerializeField] public float breakForce;
    [SerializeField] public float jumpForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private WheelFrictionCurve WheelSidewaysFriction;
    [SerializeField] private float WheelDamping;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private TrailRenderer frontLeftWheelTrail;
    [SerializeField] private TrailRenderer frontRightWheelTrail;
    [SerializeField] private TrailRenderer rearLeftWheelTrail;
    [SerializeField] private TrailRenderer rearRightWheelTrail;
    [SerializeField] private TrailRenderer engineFlameTrail;

    private void Start()
    {
        carBody = GetComponent<Rigidbody>();

        // Lower center of mass of car
        if (currentScene.name != "SportsCar" && currentScene.name != "Forklift")
        {
            carBody.centerOfMass = new Vector3(0, 0, 0);
        }
        else
        {
            carBody.centerOfMass = new Vector3(0, -0.5f, 0);
        }
        


        currentScene = SceneManager.GetActiveScene();
        //if (currentScene.name != "SportsCar")
        //{
        //    carBody.constraints = RigidbodyConstraints.FreezeRotationX;
        //    carBody.constraints = RigidbodyConstraints.FreezeRotationZ;
        //}

        Time.timeScale = 1f;
        //carBody.centerOfMass = new Vector3(0, -10, 0);

        // Friction Parts
        WheelSidewaysFriction = frontLeftWheelCollider.GetComponent<WheelCollider>().sidewaysFriction;
        WheelDamping = frontLeftWheelCollider.GetComponent<WheelCollider>().wheelDampingRate;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        HandleJump();
        UpdateWheels();
        UpdateFriction();
        UpdateDamping();
        UpdateSpeed();
        UpdateJump();
    }

    private void UpdateFriction()
    {
        if (!rb) {
            if (Singleton.Instance.friction)
            {
                WheelSidewaysFriction.stiffness = 5f;
                frontLeftWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                frontRightWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                rearLeftWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                rearRightWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
            }
            else
            {
                WheelSidewaysFriction.stiffness = 0.5f;
                frontLeftWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                frontRightWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                rearLeftWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
                rearRightWheelCollider.GetComponent<WheelCollider>().sidewaysFriction = WheelSidewaysFriction;
            }
        } 
    }

    private void UpdateDamping()
    {
        if (!rb)
        {
            WheelDamping = 25;

        }
        else
        {
            WheelDamping = 50;
        }

        frontLeftWheelCollider.GetComponent<WheelCollider>().wheelDampingRate = WheelDamping;
        frontRightWheelCollider.GetComponent<WheelCollider>().wheelDampingRate = WheelDamping;
        rearLeftWheelCollider.GetComponent<WheelCollider>().wheelDampingRate = WheelDamping;
        rearRightWheelCollider.GetComponent<WheelCollider>().wheelDampingRate = WheelDamping;
    }

    private void UpdateSpeed()
    {
        if (!rb) {
            if (Singleton.Instance.speed)
                {
                    motorForce = 2500;
                }
            else
                {
                    motorForce = 1500;
                }
        } else {
            motorForce = 350;
        }
    }

    private void UpdateJump()
    {
        if (!rb) {
            if (Singleton.Instance.jump)
            {
                if (currentScene.name != "Boss") 
                {

                    jumpForce = 100000;

                } else 
                {
                    jumpForce = 50000;
                }
            }
            else
            {
                jumpForce = 0;
            }
        } else {
            if (Singleton.Instance.jump)
            {
                if (currentScene.name != "Boss") 
                {

                    jumpForce = 100000 / 2;

                } else 
                {
                    jumpForce = 50000 / 2;
                }
            }
            else
            {
                jumpForce = 0;
            }
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
        isJumping = Input.GetKey(KeyCode.Return);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        //carBody.rotation.Set(0, carBody.rotation.y, 0, carBody.rotation.w);
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;

        

    }

    private void HandleJump()
    {
        bool grounded = Physics.Raycast(frontLeftWheelTransform.position, Vector3.down, 0.5f);

        if (isJumping && grounded)
        {
            carBody.AddForce(transform.up * jumpForce);
        }
        
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }



    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    protected void LateUpdate()
    {

        if (currentScene.name != "SportsCar" && currentScene.name != "Forklift")
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }

        if (Math.Abs(carBody.velocity.y) > 0.5)
        {
            frontLeftWheelTrail.emitting = false;
            frontRightWheelTrail.emitting = false;
            rearLeftWheelTrail.emitting = false;
            rearRightWheelTrail.emitting = false;
            engineFlameTrail.emitting = false;
        } else
        {
            frontLeftWheelTrail.emitting = true;
            frontRightWheelTrail.emitting = true;
            rearLeftWheelTrail.emitting = true;
            rearRightWheelTrail.emitting = true;
            engineFlameTrail.emitting = true;
        }
    }

}