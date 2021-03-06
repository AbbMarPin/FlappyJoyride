using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool start = true;
    public bool started = false;
    public float starttime;
    public float score = 1;

    public Text Multiplier;
    public Text Score;
    public Text Status;

    public Rigidbody Player;

    void Awake()
    {
        // Create an Instance of the GameManager to be used by other scripts
        Instance = this;
    }

    public bool GameState()
    {
        // Return whether the game is running or has ended
        return start;
    }

    public void GetReady()
    {
        // Remove the Tutorial Image
        //getReadyAnim.SetTrigger("Start");
        score = 0;
        started = true;
        Status.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        started = false;
        start = false;
        Time.timeScale = 1f;
        Status.gameObject.SetActive(true);
        Status.text = "GAME OVER!\nPress 'r' to restart\nScore: " + Math.Round(score);
    }


    // Start is called before the first frame update
    public void Start()
    {
        Status.text = "FlappyJoyride!\nPress Space to Start!\nSpin For More Points!";
        start = true;
    }
        
    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
            score += (Player.angularVelocity.magnitude + 1) * Time.deltaTime;
        Score.text = "Score: " + Math.Round(score);
        if (started)
            Time.timeScale = Mathf.Sqrt((float)Player.angularVelocity.magnitude+1);
    }
    void Update()
    {
        Multiplier.text = "x " + Math.Round(Player.angularVelocity.magnitude + 1, 2);
    }
}
