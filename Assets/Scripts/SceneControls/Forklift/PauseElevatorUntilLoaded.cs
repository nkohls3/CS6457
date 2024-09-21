using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseElevatorUntilLoaded : MonoBehaviour

{

    public GameObject elevatorObject;
    public GameObject mainCar;
    public GameObject elevatorCollider;

    public GameObject[] balls;

    public Animator anim;

    private bool player_is_loaded = false;
    private bool ball_is_loaded = true;

    void Start()
    {
        anim = elevatorObject.GetComponent<Animator>();
        anim.enabled = false;

    }


    void Update()
    {
        if (elevatorObject.transform.position.y == 0 && player_is_loaded && ball_is_loaded)
        {
            anim.enabled = true;
        }

        if (elevatorObject.transform.position.y == 0 && player_is_loaded && ball_is_loaded)
        {
            anim.enabled = true;
        }

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            player_is_loaded = true;
        }

        if (c.gameObject.tag == "Rock")
        {
            ball_is_loaded = true;
        }

    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            player_is_loaded = false;
        }

        if (c.gameObject.tag == "Rock")
        {
            ball_is_loaded = false;
        }
    }

}
