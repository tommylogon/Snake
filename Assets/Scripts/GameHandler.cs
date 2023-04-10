using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;
using TMPro;
using static GameOverWindow;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Linq;

[Serializable]
public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField] private  bool RunGame;
    [SerializeField] private  bool ResetLetterProgress;

    [SerializeField]
    private int gridSize = 20;

    [SerializeField]
    private SnakeController2D player;

    private LevelGrid levelGrid;




    [SerializeField] public List<Word> wordsList;

    [SerializeField]
    private int selectedWordIndex;

    private List<char> pickedUpLetterList;

    [SerializeField]
    private TypewriterEffect hintTypeWriter;

    bool wordIsInOrder = true;



    private void Awake()
    {


        instance = this;
        pickedUpLetterList = new List<char>();
        LoadingWordLogic();

        Score.InitializeStatic();

        if (RunGame)
        {
            GetComponent<UILoader>().SetUpUI();
        }




    }

    private void LoadingWordLogic()
    {
        LoadWordsList();

        if (wordsList != null || wordsList.Count == 0)
        {
            foreach (Word word in SeedData.InitialWords())
            {

                if (!wordsList.Contains(word))
                {

                    wordsList.Add(word);
                    Debug.Log("new word added");
                }
                else if (wordsList.Contains(word))
                {
                    Debug.Log("word already exists");
                    wordsList[wordsList.IndexOf(word)].language = word.language;
                    
                }
            }
        }
        if (ResetLetterProgress)
        {
            wordsList = new List<Word>(SeedData.InitialWords());
            SaveWordsList();
        }
        else
        {
            
        }
    }

    void Start()
    {
        Debug.Log("Gamehandler.start");


        levelGrid = new LevelGrid(gridSize, gridSize);

        findNextWord();


        if (RunGame)
        {

            player.Setup(levelGrid, wordsList[selectedWordIndex]);
            levelGrid.Setup(player, wordsList[selectedWordIndex]);

            hintTypeWriter.language = GameAssets.instance.selectedLanguage;
            hintTypeWriter.fullText = wordsList[selectedWordIndex].GetHint();
            hintTypeWriter.StartTextWriter();
            Invoke("HideHintText", 10);
            Timer.instance.SetInitialTime(wordsList[selectedWordIndex].GetWordLengt() * 10);
        }

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

    private void findNextWord()
    {
        bool wordFound=false;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (wordsList.Exists( w => w.isFinished == false))
        {
            Debug.Log("Not all words completed");
            while (!wordFound && stopwatch.Elapsed.TotalSeconds < 10)
            {
                selectedWordIndex = UnityEngine.Random.Range(0, wordsList.Count);

                if (!wordsList[selectedWordIndex].isFinished && wordsList[selectedWordIndex].language == GameAssets.instance.selectedLanguage)
                wordFound = true;
            }
        }
        else
        {
            Debug.Log("All words completed");
            selectedWordIndex = UnityEngine.Random.Range(0, wordsList.Count);
        }
        stopwatch.Stop();

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
        Timer.instance.PauseTimer(true);

        if(pickedUpLetterList.Count == wordsList[selectedWordIndex].letters.Length)
        {
            Score.AddScore(CheckIfWordWasPickedUpInOrder());
        }

        instance.wordsList[selectedWordIndex].UpdateWordStats(true, Timer.instance.GetTimeLeft(), Score.GetScore());
        SoundManager.PlaySound(SoundManager.Sound.PlayerWin);
        if (Score.TrySetNewHighscore())
        {
            ShowStatic(GameOverType.NewHighscore);
        }
        ShowStatic(GameOverType.Win);
        SaveWordsList();
    }

    private int CheckIfWordWasPickedUpInOrder()
    {
        
        for (int i = 0; i < pickedUpLetterList.Count; i++)
        {
            if (pickedUpLetterList[i] != wordsList[selectedWordIndex].letters[i])
            {
                wordIsInOrder = false;
            }
        }
        if (wordIsInOrder)
        {
            return pickedUpLetterList.Count * 10;
        }
        return 0;
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
        WordListWrapper wrapper = new WordListWrapper();
        wrapper.wordsList = wordsList;
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("wordsList", json);
        PlayerPrefs.Save();

    }
    public void LoadWordsList()
    {
        string json = PlayerPrefs.GetString("wordsList");
        WordListWrapper wrapper = JsonUtility.FromJson<WordListWrapper>(json);
        if(wrapper != null) wordsList = wrapper.wordsList;

    }

    public Word GetCurrentWord()
    {
        if(wordsList != null)
        {
            return wordsList[selectedWordIndex];
        }
        return null;
        
    }

    internal void ResetWord(Word word)
    {
        int index = wordsList.IndexOf(word);
        instance.wordsList[index].UpdateWordStats(false);
        SaveWordsList();
    }
    public bool IsWordFinished()
    {
        return wordIsInOrder;
    }
}

[System.Serializable]
public class WordListWrapper
{
    public List<Word> wordsList;
}