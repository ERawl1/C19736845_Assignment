using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{   
    public float speed = 5;
    public float targetSpeed = 25;
    float distanceunit = 0;

    public Text distanceMoved;

    void Start()
    {
        //Invoking distance to place as UI 
        InvokeRepeating("distance", 0, 1 / speed);
    }

   
    void Update()
    {

        //Moving the camera forward 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Speeding up the camera over time until it reaches maximum speed (target speed)
        if (speed < targetSpeed)
            speed += Time.deltaTime;
    }

    void distance()
    {
        //Finding distance to place as a UI Element
        distanceunit = distanceunit + 1;
        distanceMoved.text = distanceunit.ToString("Distance: " + distanceunit );
    }
}
