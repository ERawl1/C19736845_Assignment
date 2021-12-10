using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5;
    public float targetSpeed = 25;
    float distanceunit = 0;

    public Text distanceMoved;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * speed;


        //Invoking distance to place as UI 
        InvokeRepeating("distance", 0, 1 / speed);
    }

   
    void Update()
    {
        //speed += Time.deltaTime * acceleration;

        //rb.velocity = transform.forward * speed;

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
