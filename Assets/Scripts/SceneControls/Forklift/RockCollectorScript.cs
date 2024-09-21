using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class RockCollectorScript : MonoBehaviour
{

    public ForkliftTrigger forklift_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public RockCounter rock_counter;
    public GameObject jump_collectible;
    public JumpCollector jump_collector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (forklift_trigger.changeScene && rock_counter.rockCount >= 3 && jump_collector.jumpCollected == false)
        {
            playerCar.GetComponent<EngineSound>().enabled = false;
            playerCar.GetComponent<AudioSource>().enabled = false;

            jump_collectible.SetActive(true);

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
