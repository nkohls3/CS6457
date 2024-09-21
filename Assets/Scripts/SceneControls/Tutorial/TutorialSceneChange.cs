using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneChange : MonoBehaviour
{

    public endTutorialTrigger end_tutorial;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (end_tutorial.changeScene)
        {
            playerCar.GetComponent<EngineSound>().enabled = false;
            playerCar.GetComponent<AudioSource>().enabled = false;

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
