using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Tutorial_1_p2 : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool closeMenu_tutorial1_p2 = false;
    public GameObject player_car;
    public CarController car_controller;

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
        if (closeMenu_tutorial1_p2 == false)
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
        }
    }

    public void CloseMenu_Tutorial1_p2()
    {
        closeMenu_tutorial1_p2 = true;
    }


}
