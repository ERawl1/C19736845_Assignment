using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float turnSpeed = 90f;
    public float moveSpeed = 17f;
   

  

   private void OnTriggerEnter(Collider other)
    {

        //Stops pickups from spawning within Obstacles
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.inst.IncrementScore();

        Destroy(gameObject);

    }

    void Start()
    {

    }

    
    void Update()
    {
        //Slowly makes pickups turn 
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
