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
        ;

        timerText.text = FormatTime();


        if (timeLeft <= 0)
        {
            isTimeOut = true;

            OnTimeOut?.Invoke(this, EventArgs.Empty);

        }


    }

    public string FormatTime()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        int milliseconds = Mathf.FloorToInt((timeLeft - Mathf.Floor(timeLeft)) * 1000f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
    public string FormatTime(float timeToFormat)
    {
        int minutes = Mathf.FloorToInt(timeToFormat / 60);
        int seconds = Mathf.FloorToInt(timeToFormat % 60);
        int milliseconds = Mathf.FloorToInt((timeToFormat - Mathf.Floor(timeToFormat)) * 1000f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    public void AddTime(float timeToAdd) { timeLeft += timeToAdd; }
    public void RemoveTime(float timeToRemove) { timeLeft -= timeToRemove; }

    public bool IsTimedOut() { return isTimeOut; }

    public void PauseTimer(bool state) { isPaused = state; }


    public float GetTimeLeft() { return timeLeft; }

    public void SetInitialTime(float time) { initialTime = time; }



}
