using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_color : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public AudioSource CheckpointAudioSource;
    public AudioClip Checkpointsound;

    private void Start()
    {
        myMaterial.color = Color.blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            myMaterial.color = Color.red;
            CheckpointAudioSource.PlayOneShot(Checkpointsound);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.blue;
        }
    }*/
}

