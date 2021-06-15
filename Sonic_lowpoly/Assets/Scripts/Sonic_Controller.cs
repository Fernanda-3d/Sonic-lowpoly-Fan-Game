using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic_Controller : MonoBehaviour
{
    private CharacterController charController;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    // Start is called before the first frame update
    void Awake()
    {
        charController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate(); 
    }

   

    private void Move()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 moveDirection = transform.right;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);

        } else if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 moveDirection = -transform.right;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }

        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }
}
