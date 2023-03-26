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

    [SerializeField, Min(1)]
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
        Invoke("HideHintText", 5);
        //Timer.instance.OnTimeOut += Timer_OnTimeOut;

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
            GameOverWindow.ShowStatic(GameOverType.NewHighscore);
        }
        else if (Timer.instance.IsTimedOut())
        {
            GameOverWindow.ShowStatic(GameOverType.TimedOut);

        }
        //GameOverWindow.ShowStatic(Score.TrySetNewHighscore(), Timer.instance.IsTimedOut());

        

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

    //q: can you create the Playewon function here?
    public static void PlayerWon()
    {
        instance.selectedWord.UpdateWordStats(true, Timer.instance.GetTimeLeft());
        SoundManager.PlaySound(SoundManager.Sound.PlayerWin);
        GameOverWindow.ShowStatic(GameOverType.Win);
    }

    public void InitialWords()
    {
        wordsList.Add(new Word("BEAR", "A furry animal that hibernates in the winter."));
        wordsList.Add(new Word("APPLE", "A small fruit that is usually red or green."));
        wordsList.Add(new Word("BEE", "A flying insect that makes honey."));
        wordsList.Add(new Word("PARROT", "A type of bird that is often kept as a pet."));
        wordsList.Add(new Word("ROSE", "A type of flower that is often associated with love."));
        wordsList.Add(new Word("CAR", "A vehicle used for transportation."));
        wordsList.Add(new Word("DOG", "A domesticated mammal often kept as a pet."));
        wordsList.Add(new Word("OCEAN", "A large body of saltwater."));
        wordsList.Add(new Word("PHONE", "A device used for communication."));
        wordsList.Add(new Word("HOUSE", "A building used for shelter."));
        wordsList.Add(new Word("ELEPHANT", "A large mammal with a trunk and tusks."));
        wordsList.Add(new Word("GUITAR", "A musical instrument with strings."));
        wordsList.Add(new Word("WATER", "A clear liquid essential for life."));
        wordsList.Add(new Word("BOOK", "A written or printed work."));
        wordsList.Add(new Word("LION", "A large carnivorous mammal."));
        wordsList.Add(new Word("PIZZA", "A dish made of dough, sauce, and toppings."));
        wordsList.Add(new Word("SUN", "A star that provides light and heat."));
        wordsList.Add(new Word("CHAIR", "A piece of furniture used for sitting."));
        wordsList.Add(new Word("TREE", "A perennial plant with a single stem or trunk."));
        wordsList.Add(new Word("MOUNTAIN", "A large natural elevation of the earth's surface."));
        wordsList.Add(new Word("MUSIC", "An art form that uses sound and rhythm."));
        wordsList.Add(new Word("HORSE", "A large four-legged mammal used for riding."));
        wordsList.Add(new Word("KEYBOARD", "A device used for typing on a computer."));
        wordsList.Add(new Word("MIRROR", "A reflective surface used for viewing oneself."));
        wordsList.Add(new Word("PENCIL", "A writing tool used to make marks on paper."));
        wordsList.Add(new Word("BIRD", "A warm-blooded egg-laying vertebrate."));
        wordsList.Add(new Word("CLOUD", "A visible mass of condensed water vapor floating in the atmosphere."));
        wordsList.Add(new Word("COMPUTER", "An electronic device used for storing and processing data."));
        wordsList.Add(new Word("CUP", "A small, open container used for holding liquids."));
        wordsList.Add(new Word("FISH", "A cold-blooded aquatic vertebrate."));
        wordsList.Add(new Word("FLOWER", "A plant part that is usually brightly colored."));
        wordsList.Add(new Word("FOOTBALL", "A game played with a ball and two teams."));
    }

    private void HideHintText()
    {
        hintText.gameObject.SetActive(false);
    }
}
