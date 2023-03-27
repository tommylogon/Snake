using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;
using TMPro;
using static GameOverWindow;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField]
    private int gridSize = 20;

    [SerializeField]
    private SnakeController2D player;

    private LevelGrid levelGrid;

    

    
    private List<Word> wordsList;

    
   
    private int selectedWordIndex;

    private List<char> pickedUpLetterList;

    [SerializeField]
    private TypewriterEffect hintTypeWriter;

    public Timer timer;



    private void Awake()
    {
        

        instance = this;       
        pickedUpLetterList = new List<char>();
        wordsList = new List<Word>(SeedData.InitialWords());


        Score.InitializeStatic();

        GetComponent<UILoader>().SetUpUI();
        timer = GetComponent<UILoader>().loadedUI.GetComponentInChildren<Timer>();
        
        
    }

    void Start()
    {
        Debug.Log("Gamehandler.start");

        levelGrid = new LevelGrid(gridSize, gridSize);

        int selectedWordIndex = UnityEngine.Random.Range(0, wordsList.Count);
        ;

       
        player.Setup(levelGrid, wordsList[selectedWordIndex]);
        levelGrid.Setup(player, wordsList[selectedWordIndex]);

        hintTypeWriter.fullText = wordsList[selectedWordIndex].GetHint();
        Invoke("HideHintText", 10);
        timer.SetInitialTime(wordsList[selectedWordIndex].GetWordLengt() * 10);

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

    private void Timer_OnTimeOut(object sender, EventArgs e)
    {
        PlayerDied();
    }

    public static void PlayerDied()
    {
        Timer.instance.PauseTimer(true);

        if (Score.TrySetNewHighscore())
        {
            ShowStatic(GameOverType.NewHighscore);
        }
        else if (Timer.instance.IsTimedOut())
        {
            ShowStatic(GameOverType.TimedOut);

        }

        

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

   
    public  void PlayerWon()
    {
        
        instance.wordsList[selectedWordIndex].UpdateWordStats(true, Timer.instance.GetTimeLeft(), Score.GetScore());
        SoundManager.PlaySound(SoundManager.Sound.PlayerWin);
        GameOverWindow.ShowStatic(GameOverType.Win);
        SaveWordsList();
    }

    

    private void HideHintText()
    {
        hintTypeWriter.gameObject.SetActive(false);
    }

    internal Word GetSelectedWord()
    {
        if (wordsList[selectedWordIndex] != null)
        {
            return wordsList[selectedWordIndex];
        }
        return null;
        
    }

    public void AddPickedUpLetter(char c)
    {
        pickedUpLetterList.Add(c);
    }

    public void SaveWordsList()
    {
        string json = JsonUtility.ToJson(wordsList);
        PlayerPrefs.SetString("WordList", json);
    }
    public void LoadWordList()
    {
        string json = PlayerPrefs.GetString("WordList");

        
        if(wordsList is null)
        {
            wordsList = JsonUtility.FromJson<List<Word>>(json);
        }
        
    }

    public Word GetCurrentWord()
    {
        if(wordsList != null)
        {
            return wordsList[selectedWordIndex];
        }
        return null;
        
    }
    
}
