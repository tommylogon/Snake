using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public event EventHandler OnTimeOut;

    [SerializeField] private float initialTime = 60f;
    [SerializeField] private float timeToAdd = 10f;
    [SerializeField] private TextMeshProUGUI timerText = null;

    private float timeLeft = 0f;
    private bool isTimeOut = false;

    private bool isPaused = false;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {



        timeLeft = initialTime;


    }


    void Update()
    {
        if (isTimeOut || isPaused)
        {
            return;
        }
        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        int milliseconds = Mathf.FloorToInt((timeLeft - Mathf.Floor(timeLeft)) * 1000f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);


        if (timeLeft <= 0)
        {
            isTimeOut = true;

            OnTimeOut?.Invoke(this, EventArgs.Empty);

        }


    }
    public void AddTime()
    {
        initialTime += timeToAdd;
    }

    public bool IsTimedOut()
    {
        return isTimeOut;
    }

    public void PauseTimer(bool state)
    {
        isPaused = state;
    }


    public float GetTimeLeft()
    { 
        return timeLeft; 
    }




}
