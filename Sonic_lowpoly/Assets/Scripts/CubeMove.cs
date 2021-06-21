using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 0f;
    
     // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves Forward and back along z axis                           //Up/Down
        transform.Translate(-Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);

        //Moves Left and right along x Axis                               //Left/Right
       transform.Translate(-Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

       

       
    }






}

