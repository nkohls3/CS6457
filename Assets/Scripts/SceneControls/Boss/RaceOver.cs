using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceOver : MonoBehaviour
{
    public BossCarAI boss;
    public FinishTrigger finisher;

    private bool raceStart = false;
    private bool raceEnd = false;
    public bool raceE {
        get {return raceEnd;}
        set {}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Start"))
        {
            if (!raceStart) {
                raceStart = true;
                boss.ChangeState(BossCarAI.AIState.race);
            }
        }

        if (c.gameObject.CompareTag("Finished"))
        {
            if (raceStart & !raceEnd) {
                GameObject block = GameObject.FindGameObjectsWithTag("finishBlocker")[0];
                block.SetActive(false);
                
                raceEnd = true;
                boss.NMA.ResetPath();
                boss.ChangeState(BossCarAI.AIState.end);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // To move the car to the end if the boss wins

        // if (finisher.WON && finisher.win == "boss" && !raceEnd) {
        //     gameObject.transform.position = new Vector3(22.9f, 1f, -10.6f);
        //     gameObject.transform.rotation = new Quaternion(0, 45, 0, 0);

        //     raceEnd = true;
        // }
    }
}
