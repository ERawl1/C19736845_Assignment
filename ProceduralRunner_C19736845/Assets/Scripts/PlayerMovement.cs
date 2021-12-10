using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    //Bools regarding player movement, visible in editor
   
   public float speed = 50f;
   public float horizRange = 6f;
   public float vertiRange = 6f;
    public Animator animator;

    void Update()
    {
        if (!alive) return;

        //Finding Axes from InputManager
        //Allows the player to move in each direction except forward and back
        //The player is also clamped so they cannot go outside the bounds of the screen
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        float horizOffset = horizontalMove * speed * Time.deltaTime;
        float vertiOffset = verticalMove * speed * Time.deltaTime;

        float rawHorizPos = transform.position.x + horizOffset;
        float clampedHorizPos = Mathf.Clamp(rawHorizPos, -horizRange, horizRange);

        float rawVertiPos = transform.position.y + vertiOffset;
        float clampedVertiPos = Mathf.Clamp(rawVertiPos, -vertiRange, vertiRange);

        transform.position = new Vector3(clampedHorizPos, clampedVertiPos, transform.position.z);

        Animation();
    }

    public void Animation()
    {
        //Method for playing Player animations
        if (Input.GetKeyDown("a"))
        {
            animator.SetBool("IsTurningLeft", true);
                Debug.Log("A key was pressed");
        }

        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("IsTurningLeft", false);
        }


        if (Input.GetKeyDown("d"))
        {
            animator.SetBool("IsTurningRight", true);
                Debug.Log("D key was pressed");
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("IsTurningRight", false);
        }


        if (Input.GetKeyDown("w"))
        {
            animator.SetBool("IsTurningUp", true);
                Debug.Log("W key was pressed");
        }
        if (Input.GetKeyUp("w"))
        {
            animator.SetBool("IsTurningUp", false);
        }


        if (Input.GetKeyDown("s"))
        {
            animator.SetBool("IsTurningDown", true);
                Debug.Log("S key was pressed");
        }
        if (Input.GetKeyUp("s"))
        {
            animator.SetBool("IsTurningDown", false);
        }
    }

    public void Die()
    {
        //When called the scene will reset
        alive = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
