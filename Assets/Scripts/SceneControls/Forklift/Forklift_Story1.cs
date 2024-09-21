using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Forklift_Story1 : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool closeMenu1 = false;
    public GameObject player_car;
    public CarController car_controller;
    public MonoBehaviour rock_counter_text;
    public MonoBehaviour rock_counter_background;

    // Start is called before the first frame update
    void Start()
    {
        player_car.GetComponent<CarController>().enabled = false;
        rock_counter_background.enabled = false;
        rock_counter_text.enabled = false;
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
      if (Time.timeSinceLevelLoad >= 10) {
        closeMenu1 = true;
        rock_counter_background.enabled = true;
        rock_counter_text.enabled = true;
      }
    }


}
