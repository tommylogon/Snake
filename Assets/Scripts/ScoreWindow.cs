using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

        Score.OnHighscoreChanged += Score_OnHighscoreChanged;
        UpdateHighscore();

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
        highScoreText.text = "HIGHSCORE\n" + highscore.ToString();
    }
}
