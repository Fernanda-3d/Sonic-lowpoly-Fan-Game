using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{

    //public ParticleSystem smoke;
    // public GameObject here;
    public GameObject enemy;
    public GameObject kill;
    public GameObject die;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            // Instantiate(smoke, new Vector3(115, 9, -2), Quaternion.identity);
            //Instantiate(smoke, here.transform.position, Quaternion.identity);            
            // smoke.Play();
            Destroy(gameObject);
            Destroy(enemy);
            Destroy(kill);
            Destroy(die);
        }
           
    }

}


