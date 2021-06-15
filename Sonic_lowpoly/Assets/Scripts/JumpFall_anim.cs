using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFall_anim : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    void OnTriggerEnter(Collider other)
    {
               
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("JumpFall", true);
        }


    }
}
