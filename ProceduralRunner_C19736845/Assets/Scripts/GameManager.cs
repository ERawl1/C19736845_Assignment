using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public static GameManager inst;

    public Text scoreText;

    public void IncrementScore()
    {
        //Incrementing score for UI
        score++;
        scoreText.text = "Score: " + score;
    }

    void Awake()
    {
        inst = this;
    }
  
    void Update()
    {
        //Press R to restart the game
        if (Input.GetKeyDown("r"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Reset");
        }
    }
}
