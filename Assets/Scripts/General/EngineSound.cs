using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{

    AudioSource audioSourceRev;
    AudioSource audioSourceTerrain;

    public AudioClip grassClip;
    public AudioClip roadClip;
    public AudioClip roadblockClip;
    public float minPitch = 0.5f;
    public float maxPitch = 2.0f;

    private AudioSource grassSource;
    private AudioSource roadSource;
    private AudioSource roadblockSource;
    private VelocityReporter engineSpeed;

    float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceRev = GetComponents<AudioSource>()[0];
        audioSourceTerrain = GetComponents<AudioSource>()[1];
        engineSpeed = GetComponent<VelocityReporter>();
        audioSourceRev.pitch = minPitch;
        audioSourceRev.PlayDelayed(1);
    }

    // Update is called once per frame
    void Update()
    {
        engineSpeed = GetComponent<VelocityReporter>();
        // Get max speed (usually between 0 and 10)
        speed = engineSpeed.velocity.magnitude;
        // Normalize speed between 0 and 1
        speed = speed / 20f + 0.5f;

        if (speed < minPitch)
        {
            audioSourceRev.pitch = minPitch;
        }
        else if (speed > maxPitch)
        {
            audioSourceRev.pitch = maxPitch;
        }
        else
        {
            audioSourceRev.pitch = speed;
        }
    }

    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            audioSourceTerrain.clip = roadblockClip;
            audioSourceTerrain.Play();
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.gameObject.tag == "RoadBlock") {
            audioSourceTerrain.Stop();
        } 
    }

}
