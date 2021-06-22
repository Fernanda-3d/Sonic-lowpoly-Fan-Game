using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killTrigger : MonoBehaviour
{
    public GameObject smoke;
    public GameObject test_die;
    

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
        if (other.gameObject.tag == "Player")
        {
            smoke.GetComponent<BoxCollider>().enabled = false;
            test_die.GetComponent<BoxCollider>().enabled = true;
        }

                 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            smoke.GetComponent<BoxCollider>().enabled = true;
            
        }

    }

   
}


