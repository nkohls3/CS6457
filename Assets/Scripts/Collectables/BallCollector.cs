using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public bool speed = false;
    public bool jump = false;
    public bool friction = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = Singleton.Instance.speed;
        jump = Singleton.Instance.jump;
        friction = Singleton.Instance.friction;
    }

    public void Speed()
    {
        speed = true;
    }

    public void Jump()
    {
        jump = true;
    }

    public void Friction()
    {
        friction = true;
    }
}
