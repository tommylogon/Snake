using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField]
    private int gridSize = 20;

    [SerializeField]
    private SnakeController2D player;
    
    private LevelGrid levelGrid;
    
    [SerializeField,Min(1)]
    private int MaxInitializedFoodAtATime;

    [SerializeField]
    private List<Word> wordsList;

    [SerializeField]
    private Word selectedWord;

    [SerializeField]
    private TextMeshPro hintText;
    private void Awake()
    {
        instance = this;
        wordsList = new List<Word>();
        InitialWords();


        Score.InitializeStatic();
    }

    void Start()
    {
        Debug.Log("Gamehandler.start");

        levelGrid = new LevelGrid(gridSize, gridSize);
        selectedWord = wordsList[UnityEngine.Random.Range(0, wordsList.Count)];
        player.Setup(levelGrid, selectedWord);
        levelGrid.Setup(player, selectedWord);

        hintText.text = selectedWord.GetHint();
       

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
  

    public static void PlayerDied()
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

    public void InitialWords()
    {
        wordsList.Add(new Word("BEAR", "A furry animal that hibernates in the winter."));
        wordsList.Add(new Word("APPLE", "A small fruit that is usually red or green."));
        wordsList.Add(new Word("BEE", "A flying insect that makes honey."));
        wordsList.Add(new Word("PARROT", "A type of bird that is often kept as a pet."));
        wordsList.Add(new Word("ROSE", "A type of flower that is often associated with love."));
    }
}
