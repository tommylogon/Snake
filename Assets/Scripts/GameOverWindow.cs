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
    private GameObject newHighscoreText;
    
    [SerializeField]
    private GameObject timeoutText;
    
    [SerializeField]
    private TextMeshProUGUI highscoreText;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private Button_UI retryBtn;

    private void Awake()
    {
        instance = this;
        if (retryBtn == null) 
        {
            retryBtn = transform.Find("retryBtn").GetComponent<Button_UI>();
        }
        if (newHighscoreText == null)
        {
            newHighscoreText = transform.Find("newHighscoreText").gameObject;
        }

        if (scoreText == null)
        {
            scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }
        if (newHighscoreText == null)
        {
            highscoreText = transform.Find("highscoreText").GetComponent<TextMeshProUGUI>();
        }
        if(timeoutText == null)
        {
            timeoutText = transform.Find("timeoutText").gameObject;
        }

        retryBtn.ClickFunc = () => {
            Loader.Load(Loader.Scene.MainMenu);
        };

        Hide();
    }

    private void Show(bool isNewHighscore, bool isTimedOut)
    {
        gameObject.SetActive(true);


        newHighscoreText.SetActive(isNewHighscore);
        timeoutText.SetActive(isTimedOut);
        
        scoreText.text = Score.GetScore().ToString();
        
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic(bool isnewHighscore, bool isTimedOut)
    {

        instance.Show(isnewHighscore, isTimedOut);
    }
}
