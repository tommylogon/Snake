using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private float timeLeft;
    [SerializeField]
    private float timeToAdd;

    public static Timer instance;

    private bool timeOut =false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startTime = Time.time;
        timeLeft = 60.0f; // Set the timer to 1 minute
    }

    // Update is called once per frame
    void Update()
    {
        float timeElapsed = Time.time - startTime;
        timeLeft = 60.0f - timeElapsed;

        // Display the time left in the format of minute:second.millisecond
        int minutes = Mathf.FloorToInt(timeLeft / 60.0f);
        int seconds = Mathf.FloorToInt(timeLeft % 60.0f);
        int milliseconds = Mathf.FloorToInt((timeLeft - Mathf.Floor(timeLeft)) * 1000);

        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);

        // End the game when the timer reaches 0
        if (timeLeft <= 0)
        {
            timeOut = true;
            SnakeController2D.instance.PlayerDied();
        }

        
    }
    public void AddTime()
    {
        startTime += timeToAdd;
    }

    public bool IsTimedOut()
    {
        return timeOut;
    }
}
