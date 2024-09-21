using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Story_1 : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool closeMenu1 = false;
    public GameObject player_car;
    public CarController car_controller;

    // Start is called before the first frame update
    void Start()
    {
        player_car.GetComponent<CarController>().enabled = false;
        closeMenu1 = Singleton.Instance.closeMenu1;
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
        if (closeMenu1 == false)
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

    public void CloseMenu1()
    {
        closeMenu1 = true;
        Singleton.Instance.closeMenu1 = true;
    }


}
