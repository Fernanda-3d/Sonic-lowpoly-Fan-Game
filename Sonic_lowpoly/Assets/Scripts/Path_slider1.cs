using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Path_slider1 : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);

    }
}
