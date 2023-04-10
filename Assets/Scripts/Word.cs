using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameAssets;

[Serializable]
public class Word 
{
    public string letters;
    public string hint;
    public bool isFinished;
    public float time;
    public int score;
    public Language language;
    public int difficulty;

    public Word(string newletters, string desc, Language newLanguage, int newDifficulty)
    {
        letters = newletters;
        hint = desc;
        isFinished = false;
        time = letters.Length;
        language = newLanguage;
        difficulty = newDifficulty;

    }

    public void UpdateWordStats(bool isFinished, float newTime, int newScore)
    {
        this.isFinished = isFinished;
        if (newTime > time)
        {
            time = newTime;
        }
        if(newScore > score)
        {
            score = newScore;
        }

    }
    public void UpdateWordStats(bool isFinished)
    {
        this.isFinished = isFinished;
        

    }

    public int GetWordLengt()
    {
        return letters.Length;
    }

    public string GetWord()
    {
        return letters;
    }
    public string GetHint()
    {
        return hint;
    }
      
    public bool GetFinished()
    {
        return isFinished;
    }
    public int GetScore() { return score; }
    public float GetTime() { return time; }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Word))
        {
            return false;
        }

        Word other = (Word)obj;
        return letters == other.letters;
    }

    public override int GetHashCode()
    {
        return letters.GetHashCode();
    }
}
