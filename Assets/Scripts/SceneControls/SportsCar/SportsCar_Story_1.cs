using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SportsCar_Story_1 : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool closeMenu1 = false;
    public GameObject player_car;
    public CarController car_controller;
    public Text text;

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
            
            float t = SpeedCollector.MT;

            text.text = "So you want to be fast, huh? How about you show me what you got first!" 
                            + " See that track behind you? Beat the track record of " + t.ToString()
                            + " seconds and I'll give you something that'll put some pep in your step." 
                            + " Come back to me once you're done.";
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
        }
    }
}
