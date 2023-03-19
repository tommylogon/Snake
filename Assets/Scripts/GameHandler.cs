using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField]
    private int gridSize = 20;

    [SerializeField]
    private SnakeController2D snake;

    

    private LevelGrid levelGrid;

    

    [SerializeField,Min(1)]
    private int MaxInitializedFoodAtATime;

    private void Awake()
    {
        instance = this;
        Score.InitializeStatic();
    }

    void Start()
    {
        Debug.Log("Gamehandler.start");

        levelGrid = new LevelGrid(gridSize, gridSize);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake, MaxInitializedFoodAtATime);

       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused())
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            
        }
    }
  

    public static void SnakeDied()
    {
        
        GameOverWindow.ShowStatic(Score.TrySetNewHighscore(), Timer.instance.IsTimedOut());
        ScoreWindow.HideStatic();
    }
    public static void ResumeGame()
    {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }
    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }
}
