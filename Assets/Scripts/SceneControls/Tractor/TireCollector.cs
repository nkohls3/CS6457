using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TireCollector : MonoBehaviour
{

    public int tireTreeCount;
    public bool tiresCollected;
    public TextMeshProUGUI countText;

    private int numTiresCollected;

    void Start()
    {
        numTiresCollected = 0;
        tireTreeCount = 0;
        tiresCollected = false;
        SetCountText();
    }

    public void SetCountText()
    {
        countText.text = tireTreeCount.ToString() + "/50 lbs collected";
    }


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("CollectibleTree"))
        {
            c.gameObject.SetActive(false);
            tireTreeCount = tireTreeCount + 1;
            SetCountText();
        }

        if (c.gameObject.CompareTag("CollectibleTire"))
        {
            c.gameObject.SetActive(false);
            numTiresCollected++;
            
            if (numTiresCollected == 4)
            {
                Singleton.Instance.friction = true;
                tiresCollected = true;
            }
        }
    }



}
