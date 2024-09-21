using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    private float initialTime;
    private float timeCount;
    private bool count;
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        count = false;
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (count) {
            timeCount = Time.time - initialTime;
            //Debug.Log(timeCount);
            if (timeCount >= .006f) {
                QuitReal();
            }
        } else {
            initialTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.X)) {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        count = true;
        credits.SetActive(true);
    }

    public void QuitReal() {
        
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
