using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Tutorial_2 : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool closeMenu_tutorial2 = false;
    public Tutorial_1_p2 tutorial_1_p2;
    public GameObject player_car;
    public CarController car_controller;

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
        if (closeMenu_tutorial2 == false && tutorial_1_p2.closeMenu_tutorial1_p2 == true)
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
        if (closeMenu_tutorial2 == true && tutorial_1_p2.closeMenu_tutorial1_p2 == true)
        {
            player_car.GetComponent<CarController>().enabled = true;
        }
    }

    public void CloseMenu_Tutorial2()
    {
        closeMenu_tutorial2 = true;
    }


}