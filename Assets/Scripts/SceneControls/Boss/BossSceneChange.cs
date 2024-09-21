using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class BossSceneChange : MonoBehaviour
{
    public BossTrigger boss_trigger;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;

    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (boss_trigger.changeScene)
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
