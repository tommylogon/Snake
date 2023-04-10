using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    
    [SerializeField]
    private GameObject gameStateText;
    
    [SerializeField]
    private TextMeshProUGUI highscoreText;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private Button_UI continueBtn;

    private Button_UI MainMenuBtn;

    public enum GameOverType
    {
        NewHighscore,
        TimedOut,
        Win
    }

    private void Awake()
    {
        instance = this;
        if (continueBtn == null) 
        {
            continueBtn = transform.Find("continueBtn").GetComponent<Button_UI>();
        }
        if (MainMenuBtn == null)
        {
            MainMenuBtn = transform.Find("MainMenuBtn").GetComponent<Button_UI>();
        }
        if (gameStateText == null)
        {
            gameStateText = transform.Find("newHighscoreText").gameObject;
        }

        if (scoreText == null)
        {
            scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }
        if (gameStateText == null)
        {
            highscoreText = transform.Find("highscoreText").GetComponent<TextMeshProUGUI>();
        }

        continueBtn.ClickFunc = () => {
            Loader.Load(Loader.Scene.Medium);
        };
        MainMenuBtn.ClickFunc = () => {
            Loader.Load(Loader.Scene.MainMenu);
        };

        Hide();
    }

    private void Show(GameOverType gameOverType)
    {
        gameObject.SetActive(true);
       
        switch (gameOverType)
        {
            case GameOverType.NewHighscore:
                gameStateText.SetActive(true);
                gameStateText.GetComponent<TextMeshProUGUI>().text = "NEW HIGHSCORE";
                break;
            case GameOverType.TimedOut:
                gameStateText.SetActive(true);
                gameStateText.GetComponent<TextMeshProUGUI>().text = "TIMED OUT";
                break;
            case GameOverType.Win:
                gameStateText.SetActive(true);
                gameStateText.GetComponent<TextMeshProUGUI>().text = "YOU WIN";
                break;
        }
        
        scoreText.text = "SCORE: " + Score.GetScore().ToString() + "\r\nTime: " + Timer.instance.FormatTime() + "\r\n in order:" + GameHandler.instance.IsWordFinished().ToString();
        
        
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }


    public static void ShowStatic(GameOverType gameOverType)
    {
        instance.Show(gameOverType);
    }

}
