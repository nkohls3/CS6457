using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Story_2 : MonoBehaviour
{

    public TractorTrigger tractor_trigger;
    public bool closeMenu2 = false;
    public bool just_finished_tractor = false;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    private bool already_triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCar.GetComponent<CarController>().enabled = false;
        closeMenu2 = Singleton.Instance.closeMenu2;
        just_finished_tractor = Singleton.Instance.just_finished_tractor;
    }

    // Update is called once per frame
    void Update()
    {
        if (tractor_trigger.changeScene && Singleton.Instance.friction)
        {
            if ((closeMenu2 == false && !already_triggered) || just_finished_tractor)
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
                playerCar.GetComponent<CarController>().enabled = true;
                already_triggered = true;
            }
        }

        if (!tractor_trigger) {
            already_triggered = false;
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


    public void CloseMenu2()
    {
        closeMenu2 = true;
        Singleton.Instance.closeMenu2 = true;
        Singleton.Instance.just_finished_tractor = false;
    }

}