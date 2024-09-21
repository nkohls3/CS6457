using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    // Collectibles
    public bool speed = false;
    public bool jump = false;
    public bool friction = false;

    // Story Dialogue
    public bool closeMenu1 = false;
    public bool closeMenu1_p2 = false;
    public bool closeMenu1_p3 = false;
    public bool closeMenu2 = false;
    public bool closeMenu3 = false;
    public bool closeMenu4 = false;

    // tutorial finished
    public bool tutorial = false;

    //transition
    public bool just_finished_tractor = false;

    // Player position
    public Vector3 playerPos = new Vector3(-40.4000015f, 0f, -49.0999985f);
    public Quaternion playerRot = new Quaternion(0, 0, 0, 1);


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AreCollected() {
        return speed && jump && friction;
    }

}
