using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Tractor_Story_1 : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool closeMenu1 = false;
    public GameObject player_car;
    public CarController car_controller;
    public GameObject wolf;
    public GameObject counter;
    public GameObject reminder;

    // Start is called before the first frame update
    void Start()
    {
        player_car.GetComponent<CarController>().enabled = false;
    }


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group Empty");
        }

    }

    void Update()
    {
        // Open the dialogue the first time the scene is loaded
        if (closeMenu1 == false && Time.timeSinceLevelLoad >= 10)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
            player_car.GetComponent<CarController>().enabled = true;
        }
    }

    public void CloseMenu1()
    {
        if (Time.timeSinceLevelLoad >= 0.01) {
            counter.SetActive(true);
            reminder.SetActive(true);
            wolf.SetActive(true);
            closeMenu1 = true;
        }

    }


}
