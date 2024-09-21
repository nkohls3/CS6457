using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishOnCollision : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            meshRenderer.enabled = false;
        }
    }
}
