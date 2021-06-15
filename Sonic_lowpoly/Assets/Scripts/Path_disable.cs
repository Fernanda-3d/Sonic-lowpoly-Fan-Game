using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_disable : MonoBehaviour
{
    public GameObject Sonic;

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
        Sonic.GetComponent<Path_loop>().enabled = false;

    }
}
