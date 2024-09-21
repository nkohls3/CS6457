using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public BallCollector ball_collector;

    Scene currentScene;

    public void RestartScene()
    {
        Time.timeScale = 1.0f;
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoToMain()
    {
        StoreUpgrades();
        SceneManager.LoadScene("Main");
        
        if (!Singleton.Instance.tutorial) {
            Singleton.Instance.tutorial = true;
            Singleton.Instance.playerPos = new Vector3(-40,0.129999995f,-40);
            Singleton.Instance.playerRot = new Quaternion(0, 0, 0, 1);
        }
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoToTractor()
    {
        StoreUpgrades();
        // Store current position of car
        Singleton.Instance.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Singleton.Instance.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        SceneManager.LoadScene("Tractor");
    }

    public void GoToSportsCar()
    {
        StoreUpgrades();
        // Store current position of car
        Singleton.Instance.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Singleton.Instance.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        SceneManager.LoadScene("SportsCar");
    }

    public void GoToForklift()
    {
        StoreUpgrades();
        // Store current position of car
        Singleton.Instance.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Singleton.Instance.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        SceneManager.LoadScene("Forklift");
    }

    public void GoToBoss()
    {
        StoreUpgrades();
        // Store current position of car
        if (Singleton.Instance.tutorial) {
            Singleton.Instance.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Singleton.Instance.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        }
        SceneManager.LoadScene("Boss");
    }

    public void StoreUpgrades()
    {
        // Store upgrade values and load new scene
        Singleton.Instance.speed = ball_collector.speed;
        Singleton.Instance.jump = ball_collector.jump;
        Singleton.Instance.friction = ball_collector.friction;
    }
}
