using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpCollector : MonoBehaviour
{
    public bool jumpCollected;

    // Start is called before the first frame update
    void Start()
    {
        jumpCollected = false;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("JumpCollect"))
        {
            c.gameObject.SetActive(false);
            jumpCollected = true;
            Singleton.Instance.jump = true;
        }
    }

}
