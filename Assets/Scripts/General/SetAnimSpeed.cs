using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimSpeed : MonoBehaviour
{
    public Animator animator;
    public float desiredSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator.speed = desiredSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
