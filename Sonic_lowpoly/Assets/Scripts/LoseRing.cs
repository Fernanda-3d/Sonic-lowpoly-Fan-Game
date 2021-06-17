using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseRing : MonoBehaviour
{
    public AudioSource loseSound;
    public AudioClip losering;
    public ParticleSystem ringEffect;
      

    void OnTriggerEnter(Collider other)

        {
        if (other.gameObject.tag == "Player")

        loseSound.PlayOneShot(losering);
        ringEffect.Play();
        ScoringSystem.theScore = 0;
       
          }
   }
