using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTv : MonoBehaviour
{
    public AudioSource collectSound;
    public AudioClip ringSound;
    public ParticleSystem star;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        collectSound.PlayOneShot(ringSound);
        star.Play();
        ScoringSystem.theScore += 10;
        Destroy(gameObject);
    }
}
