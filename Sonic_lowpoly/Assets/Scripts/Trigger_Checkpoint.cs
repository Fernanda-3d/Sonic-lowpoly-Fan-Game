using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Checkpoint : MonoBehaviour
{

    public GameObject checkpoint;

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
        checkpoint.GetComponent<Checkpoint_Rotate>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        checkpoint.GetComponent<Checkpoint_Rotate>().enabled = false;
    }
}

