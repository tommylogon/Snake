using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score 
{

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
        SoundManager.PlaySound(SoundManager.Sound.PlayerPickup);
        score += 100;
    }
    public static void RemoveScore()
    {
        SoundManager.PlaySound(SoundManager.Sound.PickupWrong);
        score -= 50;

    }
    public static int GetHighscore()
    {
        return GameHandler.instance.GetCurrentWord().GetScore();

    }
    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighscore(score, timeLeft);
    }
    public static bool TrySetNewHighscore(int score, float time)
    {
        int oldScore = GameHandler.instance.GetCurrentWord().GetScore();
        float oldTime = GameHandler.instance.GetCurrentWord().GetTime();
        if (score > oldScore || time > oldTime)
        {
            
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }


}
