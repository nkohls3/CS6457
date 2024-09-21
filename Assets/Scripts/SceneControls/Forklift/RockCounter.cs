using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockCounter : MonoBehaviour
{

    public int rockCount;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        rockCount = 0;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = rockCount.ToString() + "/3 Rocks";
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Rock"))
        {
            rockCount = rockCount + 1;
            SetCountText();
        }
    }



}
