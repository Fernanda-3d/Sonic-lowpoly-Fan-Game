using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 360 * Time.deltaTime, 0.0f);
    }
}
