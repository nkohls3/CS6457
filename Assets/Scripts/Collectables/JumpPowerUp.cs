using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float jumpMultiplier;
    private AudioSource audioSource;
    private Animator anim;

    void Awake() {
      audioSource = GetComponent<AudioSource>();
      anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody) {
          if (c.gameObject.gameObject.tag == "Rock") {
            audioSource.Play();
            anim.SetBool("trigger", true);
          }
    

            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();

            if (bc && !bc.jump) {
                Destroy(this.gameObject);

                GameObject current = c.attachedRigidbody.gameObject;
                CarController cc = current.GetComponent<CarController>();
                if(cc) {
                    cc.jumpForce += jumpMultiplier;
                }

                bc.jump = true;
            }
        }
    }
}
