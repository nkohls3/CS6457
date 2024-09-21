using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockAI : MonoBehaviour
{
    private BossCarAI bossAi;
    // Start is called before the first frame update
    void Start()
    {
        bossAi = GetComponent<BossCarAI>();
    }

    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            bossAi.RB = true;
            bossAi.ChangeSpeed(3.5f);
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            bossAi.RB = false;
            bossAi.ChangeSpeed(bossAi.regSpeed);
        }
    }
}
