using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Calling Player script
    PlayerMovement playerMovement;
   

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();       
    }

    void OnCollisionEnter(Collision collision)
    {
        //If the player collides with an obstacle the game is reset (Calls die function from player script)
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
           

        }

    }
}
