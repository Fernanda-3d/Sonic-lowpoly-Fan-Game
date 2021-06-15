using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watersound_trigger : MonoBehaviour
{
    public GameObject watersoundtrigger;
    
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")

        watersoundtrigger.GetComponent<BoxCollider>().enabled = true;
       

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")

            watersoundtrigger.GetComponent<BoxCollider>().enabled = false;
          

    }


}
