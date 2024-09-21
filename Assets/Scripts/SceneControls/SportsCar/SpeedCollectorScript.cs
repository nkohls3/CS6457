using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class SpeedCollectorScript : MonoBehaviour
{
    public SportsCarTrigger sportscar_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public SpeedCollector speed_collector;
    public GameObject speedCollectable;
    public GameObject timer;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sportscar_trigger.changeScene && speed_collector.raceS && speed_collector.HitMidpoint() && speed_collector.speedCollected == false)
        {
            playerCar.GetComponent<EngineSound>().enabled = false;
            playerCar.GetComponent<AudioSource>().enabled = false;

            timer.SetActive(false);

            if (speed_collector.GoodTime()) {

                speedCollectable.SetActive(true);

                text.text = "HOLY SMOKES! You're super fast! Here, take this power-up." 
                        + " This will help you in the big race later today!";
            } else {
                text.text = "Sorry, you weren't fast enough. Try again.";
            }

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Time.timeScale = 0.001f;
        }
    }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group Empty");
        }

    }
}
