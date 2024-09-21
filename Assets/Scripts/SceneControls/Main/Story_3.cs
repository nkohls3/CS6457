using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Story_3 : MonoBehaviour
{

    public ForkliftTrigger forklift_trigger;
    public bool closeMenu3 = false;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    // Start is called before the first frame update
    void Start()
    {
        playerCar.GetComponent<CarController>().enabled = false;
        closeMenu3 = Singleton.Instance.closeMenu3;
    }

    // Update is called once per frame
    void Update()
    {
        if (forklift_trigger.changeScene && Singleton.Instance.jump)
        {
            if (closeMenu3 == false)
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


    public void CloseMenu3()
    {
        closeMenu3 = true;
        Singleton.Instance.closeMenu3 = true;
    }

}