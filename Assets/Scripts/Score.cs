using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score 
{

    //q:i want to make it so that the hightscore is a combination of the current word, and the time left.
    //a:   you can make a new class that holds the score and the time left, and then make a list of those classes, a
    //nd then sort the list by score, and then set the highscore to the first item in the list.




   

    public static event EventHandler OnHighscoreChanged;
    private static int score;
    private static float timeLeft;

    public static void InitializeStatic()
    {
        OnHighscoreChanged = null;
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
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }
    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighscore(score);
    }
    public static bool TrySetNewHighscore(int score)
    {
        int highscore = GetHighscore();
        if(score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }
}
