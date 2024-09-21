using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class SportsCarSceneChange : MonoBehaviour
{

    public SportsCarTrigger sportscar_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public SpeedCollector speed_collector;

    Scene currentScene;


    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Main")
        {
            if (sportscar_trigger.changeScene && Singleton.Instance.speed == false)
            {
                playerCar.GetComponent<EngineSound>().enabled = false;
                playerCar.GetComponent<AudioSource>().enabled = false;

                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0.001f;
            }
        }
            
        else if (currentScene.name == "SportsCar")
        {
            if (sportscar_trigger.changeScene && speed_collector.speedCollected)
            {
                playerCar.GetComponent<EngineSound>().enabled = false;
                playerCar.GetComponent<AudioSource>().enabled = false;

                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0.001f;
            }
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
