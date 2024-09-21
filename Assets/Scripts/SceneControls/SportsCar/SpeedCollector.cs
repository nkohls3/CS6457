using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedCollector : MonoBehaviour
{
    public bool speedCollected;
    public bool midpointReached = false;
    public bool finalReached = false;
    public TextMeshProUGUI countText;

    public GameObject start_collider;
    public GameObject start_text;

    public GameObject midpoint_collider;
    public GameObject midpoint_text;

    public GameObject end_collider;
    public GameObject end_text;


    public static float MT = 80;
    private float maxTime = 80;

    private bool count = false;
    private bool midpt = false;
    private bool raceStart = false;
    private bool goAgain = true;

    private float timeCount;
    private float initialTime;
    public bool raceS {
        get {return raceStart;}
        set {}
    }

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        Time.timeScale =1f;
        initialTime = Time.time;
        speedCollected = false;

        start_collider.SetActive(true);
        start_text.SetActive(true);

        midpoint_collider.SetActive(true);
        midpoint_text.SetActive(true);

        end_collider.SetActive(true);
        end_text.SetActive(true);
    }

    public bool GoodTime() {
        return timeCount <= maxTime;
    }

    public bool HitMidpoint()
    {
        return midpointReached && finalReached;
    }

    void SetCountText()
    {
        countText.text = timeCount.ToString("0.00") + " seconds";
    }

    private void OnTriggerEnter(Collider c)
    {              
        if (c.gameObject.CompareTag("Start") && goAgain) {
            count = true;
            raceStart = true;
            midpt = false;
            midpointReached = false;
            finalReached = false;

            midpoint_collider.SetActive(true);
            midpoint_text.SetActive(true);

            start_collider.SetActive(false);
            start_text.SetActive(false);


        }

        if (c.gameObject.CompareTag("Finished")) {
            if (raceStart && midpt) {
                count = false;
                finalReached = true;
                if (GoodTime() && HitMidpoint()) {
                    end_collider.SetActive(false);
                    end_text.SetActive(false);
                    goAgain = false;
                } else
                {
                    start_collider.SetActive(true);
                    start_text.SetActive(true);

                    midpoint_collider.SetActive(true);
                    midpoint_text.SetActive(true);
                }
            }
        }
        
        if (c.gameObject.CompareTag("SpeedCollect")) {
            c.gameObject.SetActive(false);
            speedCollected = true;
            countText.text = "";
            Singleton.Instance.speed = true;
        }

        if (c.gameObject.CompareTag("midpt")) {
            midpt = true;
            midpointReached = true;
            midpoint_collider.SetActive(false);
            midpoint_text.SetActive(false);
        }
    }

    private void Update() {
        if (count) {
            timeCount = Time.time - initialTime;
            SetCountText();
        } else {
            initialTime = Time.time;
        }
    }
}