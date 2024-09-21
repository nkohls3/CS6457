using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private string winner;  
    private bool won = false;
    public string win {
        get {return winner;}
        set {winner = value;}
    }
    public bool WON {
        get {return won;}
        set {won = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && !won)
        {
            winner = "player";
            won = true;
        } 
    }
}
