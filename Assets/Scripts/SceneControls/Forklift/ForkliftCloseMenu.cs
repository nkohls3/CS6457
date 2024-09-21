using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class ForkliftCloseMenu : MonoBehaviour
{
    public ForkliftTrigger forklift_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    // Update is called once per frame
    public void StopMenu()
    {
        playerCar.GetComponent<EngineSound>().enabled = true;
        playerCar.GetComponent<AudioSource>().enabled = true;

        Time.timeScale = 1f;
        forklift_trigger.changeScene = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
    }
}

