using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_enable : MonoBehaviour
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
        Sonic.GetComponent<Path_loop>().enabled = true;
        Roll.PlayOneShot(roll);
       
    }

}
