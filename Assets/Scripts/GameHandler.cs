using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    [SerializeField]
    private int gridSize = 20;

    [SerializeField]
    private SnakeController2D snake;

    private LevelGrid levelGrid;

    private static int score;

    [SerializeField,Min(1)]
    private int MaxInitializedFoodAtATime;

    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }

    void Start()
    {
        Debug.Log("Gamehandler.start");

        levelGrid = new LevelGrid(gridSize, gridSize);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake, MaxInitializedFoodAtATime);

       

    }
    private static void InitializeStatic()
    {
        score = 0;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public static void SnakeDied()
    {
        GameOverWindow.ShowStatic();
    }
}
