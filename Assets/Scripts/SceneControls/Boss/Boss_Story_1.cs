using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Story_1 : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool closeMenu1 = false;
    public GameObject player_car;
    public CarController car_controller;
    public GameObject boss_car;

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

    public void StartState() {
        boss_car.GetComponent<BossCarAI>().ChangeState(BossCarAI.AIState.start);
    }
}
