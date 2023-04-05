using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{

    private static ScoreWindow instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        instance = this;
        if(scoreText == null)
        {
            scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }
        if (highScoreText == null)
        {
            highScoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        }
        
        

        Score.OnHighscoreChanged += Score_OnHighscoreChanged;
        

    }
    private void Start()
    {
        UpdateHighscore();
    }
    private void OnDisable()
    {
        Score.OnHighscoreChanged -= Score_OnHighscoreChanged;
    }

    private void Score_OnHighscoreChanged(object sender, System.EventArgs e)
    {
        UpdateHighscore();
    }
    private void Update()
    {
        scoreText.text = Score.GetScore().ToString();
    }

    private void UpdateHighscore()
    {
        int highscore = Score.GetHighscore();
        string time = Timer.instance.FormatTime(GameHandler.instance.GetCurrentWord().GetTime());
        highScoreText.text = "HIGHSCORE\n" + highscore.ToString() + "\r\n" + time;
    }

    public static void HideStatic()
    {
        instance.gameObject.SetActive(false);
    }
    public static void ShoweStatic()
    {
        instance.gameObject.SetActive(true);
    }
}
