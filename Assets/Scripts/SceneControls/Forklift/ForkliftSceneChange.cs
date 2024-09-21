using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class ForkliftSceneChange : MonoBehaviour
{

    public ForkliftTrigger forklift_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public JumpCollector jump_collector;

    Scene currentScene;


    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Main")
        {
            if (forklift_trigger.changeScene && Singleton.Instance.jump == false)
            {
                playerCar.GetComponent<EngineSound>().enabled = false;
                playerCar.GetComponent<AudioSource>().enabled = false;

                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0.001f;
            }
        }

        else if (currentScene.name == "Forklift")
        {
            if (forklift_trigger.changeScene && jump_collector.jumpCollected)
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
