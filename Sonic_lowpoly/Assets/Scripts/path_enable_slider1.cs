using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path_enable_slider1 : MonoBehaviour
{

    public GameObject Sonic;
    public AudioSource Roll;
    public AudioClip roll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Sonic.GetComponent<Path_slider1>().enabled = true;
        Roll.PlayOneShot(roll);
    }
}


