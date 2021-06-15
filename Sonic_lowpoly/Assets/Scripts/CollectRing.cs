using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRing : MonoBehaviour
{
    public AudioSource collectSound;
    public AudioClip ringSound;
    public ParticleSystem star;
    

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")

        collectSound.PlayOneShot(ringSound);
        star.Play();        
        ScoringSystem.theScore += 1;
        Destroy(gameObject);
    }
           
}

