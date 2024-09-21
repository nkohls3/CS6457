using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPrevious : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the players position
        GameObject.FindGameObjectWithTag("Player").transform.position = Singleton.Instance.playerPos;
        // Set the players orientation
        GameObject.FindGameObjectWithTag("Player").transform.rotation = Singleton.Instance.playerRot;
    }
}
