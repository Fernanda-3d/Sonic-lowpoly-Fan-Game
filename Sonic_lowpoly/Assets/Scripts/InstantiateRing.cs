using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRing : MonoBehaviour
{

    public GameObject ring1;
 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

            Instantiate(ring1, transform.position, transform.rotation);
      
              

    }
}
