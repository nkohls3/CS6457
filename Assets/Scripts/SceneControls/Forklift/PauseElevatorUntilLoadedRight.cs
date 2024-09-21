using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseElevatorUntilLoadedRight : MonoBehaviour

{

    public GameObject elevatorObject;
    public GameObject gameObject_base_right;
    public GameObject mainCar;

    public GameObject[] balls;
    public GameObject[] glasses;
    public Material off_material;
    public Material on_material;

    public Animator anim;

    private bool player_is_loaded = false;
    private bool ball_is_loaded = true;
    private Vector3 starting_position;
    //private Vector3 car_start_position;

    private bool hit_bottom = false;

    void Start()
    {
        //elevatorObject.transform.position = new Vector3(elevatorObject.transform.position.x, 31, elevatorObject.transform.position.z);
        anim = elevatorObject.GetComponent<Animator>();
        anim.Play("Base Layer.Elevator2", -1, 0.5f);
        anim.enabled = true;
        starting_position = gameObject_base_right.transform.position;
        //car_start_position = mainCar.transform.position;

        foreach (var glass in glasses)
        {
            if (anim.enabled)
            {
                glass.GetComponent<MeshRenderer>().material = on_material;
            }
            else
            {
                glass.GetComponent<MeshRenderer>().material = off_material;
            }
        }

    }

    void Update()
    {
        if (!hit_bottom && elevatorObject.transform.position.y != starting_position.y)
        {
            return;
        }
        

        



        if (elevatorObject.transform.position.y == starting_position.y)
        {
            hit_bottom = true;
            if (player_is_loaded && ball_is_loaded)
            {
                anim.enabled = true;
            }
            else
            {
                if (mainCar.transform.position.y > 30 && mainCar.transform.position.x > 0)
                {
                    anim.enabled = true;
                }
                else
                {
                    anim.enabled = false;
                }
            }
        }

        //Debug.Log(elevatorObject.transform.position.y);
        if (elevatorObject.transform.position.y >= 5.99)
        {
            //disable when we first get to top
            if (player_is_loaded && ball_is_loaded)
            {
                anim.enabled = false;
            }
            //once the ball is off
            else
            {
                if (player_is_loaded && !ball_is_loaded)
                {
                    anim.enabled = true;
                }
                else if (!player_is_loaded && ball_is_loaded)
                {
                    anim.enabled = true;
                } 
                else if (!player_is_loaded && !ball_is_loaded && !car_is_touching_bottom(mainCar.transform.position))
                {
                    anim.enabled = false;
                } else
                {
                    anim.enabled = true;
                }

            }
        }

        //Debug.Log($"Ball: {ball_is_loaded}, Player: {player_is_loaded}");

        foreach (var glass in glasses)
        {
            if (anim.enabled)
            {
                glass.GetComponent<MeshRenderer>().material = on_material;
            }
            else
            {
                glass.GetComponent<MeshRenderer>().material = off_material;
            }
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

    bool car_is_touching_bottom(Vector3 position)
    {
        return (position.y > -0.01 && position.y < 0.01);
    }

}

