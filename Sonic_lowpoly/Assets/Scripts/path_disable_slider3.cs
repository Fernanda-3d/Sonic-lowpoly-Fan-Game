﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path_disable_slider3 : MonoBehaviour
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
        Sonic.GetComponent<path_slider3>().enabled = false;

    }
}
