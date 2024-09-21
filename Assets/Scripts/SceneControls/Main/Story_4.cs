using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Story_4 : MonoBehaviour
{

    public SportsCarTrigger sportscar_trigger;
    public bool closeMenu4 = false;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    // Start is called before the first frame update
    void Start()
    {
        playerCar.GetComponent<CarController>().enabled = false;
        closeMenu4 = Singleton.Instance.closeMenu4;
    }

    // Update is called once per frame
    void Update()
    {
        if (sportscar_trigger.changeScene && Singleton.Instance.speed)
        {
            if (closeMenu4 == false)
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


    public void CloseMenu4()
    {
        closeMenu4 = true;
        Singleton.Instance.closeMenu4 = true;
    }

}
