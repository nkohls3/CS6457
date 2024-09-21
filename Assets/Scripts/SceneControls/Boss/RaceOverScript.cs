using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceOverScript : MonoBehaviour
{
    public BossTrigger boss_trigger;
    public BossCarAI boss;
    public CanvasGroup canvasGroup;
    public GameObject playerCar;
    public RaceOver race_over;
    public FinishTrigger finisher;
    public Text text;
    public GameObject race_again;
    public GameObject back_to_main;
    public GameObject continue_story;

    // Update is called once per frame
    void Update()
    {
        if (boss_trigger.changeScene && race_over.raceE && boss.aiState == BossCarAI.AIState.end && boss.NoDist()) {
            playerCar.GetComponent<EngineSound>().enabled = false;
            playerCar.GetComponent<AudioSource>().enabled = false;

            if (finisher.win == "player") {
                text.text = "Congratulations, you win! I guess you really are the best." + 
                " Hit Race Again if you want a rematch or Quit to exit the game." ;
            } 
            else if (finisher.win == "boss") {
                // Player has not been to main scene yet
                if (Singleton.Instance.closeMenu1 == false)
                {
                    text.text = "That was pitiful! I wasn't even trying! You really should upgrade that beat up equipment. Come back if you want a rematch! I love an easy win";
                        race_again.SetActive(false);
                        continue_story.SetActive(true);
                }
                else
                {
                    string t = "You lost! Looks like I really am the best! If you want to give up go right ahead ";
                    if (Singleton.Instance.AreCollected())
                    {
                        t += "or hit Race Again if you want a rematch.";
                    }
                    else
                    {
                        t += "or hit Back To Main to try and get the rest of the powerups... Trust me you'll need them.";
                        race_again.SetActive(false);
                        back_to_main.SetActive(true);
                    }
                    text.text = t;
                }   
            }
            
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
