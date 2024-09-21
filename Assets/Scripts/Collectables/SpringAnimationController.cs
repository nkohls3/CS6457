using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnimationController : MonoBehaviour
{
    public float jumpMultiplier;
    private AudioSource audioSource;
    private Animator anim;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody)
        {
            if (c.gameObject.gameObject.tag == "Rock")
            {
                audioSource.Play();
                anim.SetBool("trigger", true);
            }
        }
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Spring"))
        {
            anim.SetBool("trigger", false);
        } 
    }

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length <
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsDonePlaying(string stateName)
    {
        return !AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
