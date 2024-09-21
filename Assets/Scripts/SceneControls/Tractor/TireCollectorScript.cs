using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class TireCollectorScript : MonoBehaviour
{
    public TractorTrigger tractor_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public TireCollector tire_collector;
    public GameObject tire_stack;
    public GameObject wolf;
    public GameObject counterMenu;
    public GameObject reminderMenu;
    public bool just_finished_tractor;

    // Start is called before the first frame update
    void Start()
    {
        just_finished_tractor = Singleton.Instance.just_finished_tractor;
    }

    // Update is called once per frame
    void Update()
    {
        if (tractor_trigger.changeScene && tire_collector.tireTreeCount >= 50 && tire_collector.tiresCollected == false)
        {
            playerCar.GetComponent<EngineSound>().enabled = false;
            playerCar.GetComponent<AudioSource>().enabled = false;

            wolf.SetActive(false);
            counterMenu.SetActive(false);
            reminderMenu.SetActive(false);
            tire_stack.SetActive(true);
            tire_collector.tireTreeCount -= 50;

            just_finished_tractor = true;

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